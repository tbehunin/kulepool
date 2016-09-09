'use strict';

var gulp = require('gulp');
var $ = require('gulp-load-plugins')();
var lazypipe = require('lazypipe');
var del = require('del');
var runSequence = require('run-sequence');
var browserify = require('browserify');
var source = require('vinyl-source-stream');
var nugetpack = require('gulp-nuget-pack');
var argv = require('yargs').argv;
var fs = require('fs');
var sass = require('gulp-sass');
var inject = require('gulp-inject');
var browserSync = require('browser-sync').create();
var rename = require('gulp-rename');

argv.env = argv.env || 'debug'; // default to debug
argv.env = argv.env.toLowerCase();

argv.ver = argv.ver || '0.0.1'; // default the version

var appDirs = {
  root: 'app',
  scripts: 'app/scripts',
  config: 'app/scripts/config',
  styles: 'app/styles',
  fonts: 'app/fonts',
  views: 'app/views',
  images: 'app/images'
};
var distDirs = {
  root: 'dist',
  scripts: 'dist/scripts',
  views: 'dist/views',
  images: 'dist/images',
  styles: 'dist/styles',
  fonts: 'dist/fonts'
};
var outputDir = 'output';
var appFiles = {
  allScripts: appDirs.scripts + '/**/*.js',
  allSass: appDirs.styles + '/**/*.scss',
  allCss: appDirs.styles + '/**/*.css',
  allViews: appDirs.views + '/**/*.html',
  allImages: appDirs.images + '/**/*',
  allFonts: [
    appDirs.fonts + '/**/*.eot',
    appDirs.fonts + '/**/*.svg',
    appDirs.fonts + '/**/*.ttf',
    appDirs.fonts + '/**/*.woff',
    appDirs.fonts + '/**/*.woff2'
  ],
  index: appDirs.root + '/index.html',
  appConfig: appDirs.config + '/appConfig.js',
  appConfigJson: appDirs.config + '/appConfig.json',
  vendorStyles: appDirs.styles + '/vendorStyles.json',
  app: appDirs.scripts + '/app.js',
  mainSass: appDirs.root + '/main.scss',
  vendorFonts: appDirs.fonts + '/vendorFonts.json'
};
var distFiles = {
  allFiles: distDirs.root + '/**/*',
  gitIgnore: distDirs + '/.gitignore'
};
var paths = {
  test: ['test/spec/**/*.js'],
  testRequire: [
    'test/mock/**/*.js',
    'test/spec/**/*.js'
  ],
  karma: 'karma.conf.js'
};
var appConfig = require('./' + appFiles.appConfigJson);
var vendorStyles = require('./' + appFiles.vendorStyles);
var vendorFonts = require('./' + appFiles.vendorFonts);

////////////////////////
// Reusable pipelines //
////////////////////////

var lintScripts = lazypipe().pipe($.jshint, '.jshintrc').pipe($.jshint.reporter, 'jshint-stylish');

///////////
// Tasks //
///////////

// gulp.task('start:server:test', function() {
// $.connect.server({
// root: ['test', appDirs.root],
// livereload: true,
// port: 9001
// });
// })

gulp.task('browsersync', ['watch'], function (cb) {
  browserSync.init({ proxy: 'localhost/kulepool' }, cb);
});

gulp.task('watch', ['build'], function () {
  gulp.watch(appFiles.allSass, ['sass']);
  gulp.watch(appFiles.allCss, ['css']);
  gulp.watch(appFiles.allViews, ['views']);
  gulp.watch(appFiles.allImages, ['images']);
  gulp.watch(appFiles.allFonts, ['fonts']);
  gulp.watch(appFiles.allScripts, ['browserify']);
  gulp.watch(appFiles.appConfigJson, ['browserify']);
  gulp.watch(appFiles.index, ['index']);
});

// gulp.task('test', ['start:server:test'], function () {
//   var testToFiles = paths.testRequire.concat(appFiles.allScripts, paths.test);
//   return gulp.src(testToFiles)
//     .pipe($.karma({
//       configFile: paths.karma,
//       action: 'watch'
//     }));
// });

///////////
// Build //
///////////

gulp.task('styles', ['sass', 'css', 'fonts']);

gulp.task('sass', function () {
  var sassFiles = vendorStyles.filter(function (item) {
    return item.endsWith('.scss');
  }).concat(appFiles.allSass);

  var injectAppFiles = gulp.src(sassFiles, { read: false, base: '.' });

  function transformFilepath(filepath) {
    return '@import "' + filepath + '";';
  }

  var injectAppOptions = {
    transform: transformFilepath,
    starttag: '// inject:app',
    endtag: '// endinject',
    addRootSlash: false
  };
  return gulp.src(appFiles.mainSass)
    .pipe(inject(injectAppFiles, injectAppOptions))
    .pipe(sass())
    .pipe(rename('compiledSass.css'))
    .pipe(gulp.dest(distDirs.styles))
    .pipe(browserSync.reload({ stream: true }));
});

gulp.task('css', function () {
  var cssFiles = vendorStyles.filter(function (item) {
    return item.endsWith('.css');
  }).concat(appFiles.allCss);

  return gulp.src(cssFiles)
    .pipe(rename('compiledCss.css'))
    .pipe(gulp.dest(distDirs.styles))
    .pipe(browserSync.reload({ stream: true }));
});

gulp.task('fonts', function () {
  vendorFonts.forEach(function (item) {
    gulp.src(item.src)
      .pipe(gulp.dest(distDirs.fonts + '/' + item.fontsSubfolder))
      .pipe(browserSync.reload({ stream: true }));
  });

  return gulp.src(appFiles.allFonts)
    .pipe(gulp.dest(distDirs.fonts))
    .pipe(browserSync.reload({ stream: true }));
});

gulp.task('lint-scripts', function () {
  return gulp.src(appFiles.allScripts)
    .pipe(lintScripts());
});

gulp.task('clean', function () {
  return del([appFiles.appConfig, distFiles.allFiles, '!' + distDirs.gitIgnore]);
});

gulp.task('index', function () {
  return gulp.src(appFiles.index)
    .pipe(gulp.dest(distDirs.root))
    .pipe(browserSync.reload({ stream: true }));
});

gulp.task('views', function () {
  return gulp.src(appFiles.allViews)
    .pipe(gulp.dest(distDirs.views))
    .pipe(browserSync.reload({ stream: true }));
});

gulp.task('images', function () {
  return gulp.src(appFiles.allImages)
    .pipe($.cache($.imagemin({ optimizationLevel: 5, progressive: true, interlaced: true })))
    .pipe(gulp.dest(distDirs.images));
});

gulp.task('build', ['clean'], function (cb) {
  runSequence(['lint-scripts', 'images', 'views', 'index', 'styles', 'browserify'], cb);
});

gulp.task('generate-app-config', function (cb) {
  var content = 'module.exports = ' + JSON.stringify(appConfig[argv.env]) + ';';
  fs.writeFile(appFiles.appConfig, content, cb);
});

gulp.task('browserify', ['generate-app-config'], function () {
  var debug = argv.env === 'debug' ? true : false;
  console.log(debug);
  return browserify(appFiles.app)
    .bundle()
    .pipe(source('bundle.js'))
    .pipe(gulp.dest(distDirs.scripts))
    .pipe(browserSync.reload({ stream: true, debug: debug }));
});

gulp.task('nuget-pack', function (cb) {
  var options = {
    id: 'CatalogAPI.UI.' + argv.env,
    version: argv.ver,
    authors: 'Rabid Kittens',
    owners: 'IDS',
    description: 'The SPA web application UI interfacing CatalogAPI.',
    outputDir: outputDir,
    excludes: [distFiles.gitIgnore]
  };
  nugetpack(options, [distFiles.allFiles], cb);
});

gulp.task('clean-output', function () {
  return del(outputDir);
});

gulp.task('nuget', ['clean-output'], function (cb) {
  runSequence('build', 'nuget-pack', cb);
});

gulp.task('default', ['build']);