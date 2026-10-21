$.validator.addMethod("notfutureyear", function (value, element, max) {
    if (!value) return true;
    return parseInt(value, 10) <= parseInt(max, 10);
});
$.validator.unobtrusive.adapters.addSingleVal("notfutureyear", "max");

$.validator.addMethod("allowedextensions", function (value, element, extensions) {
    if (!element.files || element.files.length === 0) return true;
    var name = element.files[0].name.toLowerCase();
    return extensions.split(",").some(function (ext) { return name.endsWith(ext); });
});
$.validator.unobtrusive.adapters.addSingleVal("allowedextensions", "extensions");

$(function () {
    $("input[type=file]").on("change", function () { $(this).valid(); });
});
