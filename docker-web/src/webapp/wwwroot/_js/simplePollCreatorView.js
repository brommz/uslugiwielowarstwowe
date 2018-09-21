$(function () {
    // Grab the template script
    var theTemplateScript = $("#address-template").html();

    // Compile the template
    var theTemplate = Handlebars.compile(theTemplateScript);

    // Define our data object
    var context = {
        "city": "London",
        "street": "Baker Street",
        "number": "221B"
    };

    // Pass our data to the template
    var theCompiledHtml = theTemplate(context);

    // Add the compiled html to the page
    $('.content-placeholder').html(theCompiledHtml);
});




$(function () {

    // Register a helper
    Handlebars.registerHelper('capitalize', function (str) {
        // str is the argument passed to the helper when called
        str = str || '';
        return str.slice(0, 1).toUpperCase() + str.slice(1);
    });

    // Grab the template script
    var theTemplateScript = $("#built-in-helpers-template").html();

    // Compile the template
    var theTemplate = Handlebars.compile(theTemplateScript);

    // We will call this template on an array of objects
    var context = {
        animals: [
            {
                name: "cow",
                noise: "moooo"
            },
            {
                name: "cat",
                noise: "meow"
            },
            {
                name: "fish",
                noise: ""
            },
            {
                name: "farmer",
                noise: "Get off my property!"
            }
        ]
    };

    // Pass our data to the template
    var theCompiledHtml = theTemplate(context);

    // Add the compiled html to the page
    $('.content-placeholder2').html(theCompiledHtml);

});

