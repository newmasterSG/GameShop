var gulp = require("gulp");
var del = require("del");
var paths = {
  scripts: ["Scripts/**/*.js", "Scripts/**/*.ts", "Scripts/**/*.map"],
};
gulp.task("clean", function () {
  return del(["wwwroot/scripts/**/*"]);
});
gulp.task("default", function (done) {
    gulp.src(paths.scripts).pipe(gulp.dest("wwwroot/scripts"));
    done();
});