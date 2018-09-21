var simplePollService = simplePollService();


$('.jsSaveSimplePollButton').on('click', function () {
    $(this).attr('disabled', 'disabled');

    var type = 0;
    if ($('.jsSimplePollType').is(':checked')) {
        type = 1;
    }

    var pollText = $('.jsSimplePollText').val();

    var data = {
        type: type,
        text: pollText
    };
    simplePollService.addSimplePoll(data)
        .done(function (simplePoll) {
            $(this).attr('disabled', 'disabled');
            $('.jsSimplePollId').val(simplePoll.Id);
        });
});

$(document).on("click", '.jsAddOption', function (e) {
    $('.jsSimplePollType').attr('disabled', 'disabled');

    var newOptionTemplateScript = $("#newOptionTemplate").html();
    var newOptionTemplate = Handlebars.compile(newOptionTemplateScript);

    var type = 'radio';
    if ($('.jsSimplePollType').is(':checked')) {
        type = 'checkbox';
    }

    var texts = {
        type: type,
        sampleText: 'Przykladowe pytanie',
        saveText: 'Zapisz pytanie'
    };
    var compiledHtml = newOptionTemplate(texts);
    $('.jsSimplePollOptions').append(compiledHtml);
});

$(document).on("click", '.jsSaveSimplePollOptionButton', function (e) {
    $(this).attr('disabled', 'disabled');

    var $optionText = $(this).parent().find('.jsSimplePollOptionText');
    $optionText.attr('disabled', 'disabled');

    //$(this).parent().find('.jsSimplePollOptionText').val('test zapisz pytanie');

    var data = {
        simplePollId: $('.jsSimplePollId').val(),
        text: $optionText.val()
    };
    simplePollService.addOption(data)
        .done(function (simplePoll) {
            $(this).attr('disabled', 'disabled');
            $('.jsSimplePollId').val(simplePoll.Id);
        });

});