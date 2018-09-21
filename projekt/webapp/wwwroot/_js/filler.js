function querystring(key) {
    var re = new RegExp('(?:\\?|&)' + key + '=(.*?)(?=&|$)', 'gi');
    var r = [],
        m;
    while ((m = re.exec(document.location.search)) != null) r[r.length] = m[1];
    return r;
}

function getSimplePollHtml(simplePoll) {
    var templateScript = $("#simplePollTemplate").html();
    var template = Handlebars.compile(templateScript);
    var compiledHtml = template(simplePoll);
    return compiledHtml;
}

function getSimplePollOptionHtml(simplePollOption) {
    var templateScript = $("#optionTemplate").html();
    var template = Handlebars.compile(templateScript);
    var compiledHtml = template(simplePollOption);
    return compiledHtml;
}

var simplePollService = simplePollService();

var simplePoll = null;
var simplePollId = querystring('id');
simplePollService.getSimplePoll(simplePollId)
    .done(function (data) {
        simplePoll = data;
        $('.jsSimplePoll').html(getSimplePollHtml(simplePoll));

        var $options = $('.jsSimplePoll').find('.jsSimplePollOptions');
        for (var i = 0; i < simplePoll.Options.length; i++) {
            var option = simplePoll.Options[i];
            var optionModel = {
                Id: option.Id,
                Type: simplePoll.Type == 0 ? 'radio' : 'checkbox',
                Text: option.Text
            };
            var optionHtml = getSimplePollOptionHtml(optionModel);
            $options.append(optionHtml);
        }
    });

var rtc = simplePollsRTC();
rtc.connectTo();

$(document).on("click", '.jsSaveSimplePollOptionButton', function (e) {
    $(this).attr('disabled', 'disabled');
    if (simplePoll.Type == 0) {
        $('.jsSaveSimplePollOptionButton').attr('disabled', 'disabled');
    }

    var $optionId = $(this).parent().find('.jsSimplePollOptionId');
    var $employeeName = $('.jsEmployeeName');

    var data = {
        SimplePollId: simplePoll.Id,
        SimplePollOptionId: $optionId.val(),
        EmployeeName: $employeeName.val()
    };
    
    simplePollService.addAnswerToSimplePollOption(data)
        .done(function (result) {
            //rtc.sendPollUpdated(data.SimplePollId, data.EmployeeName);
        });
    rtc.sendPollUpdated(data.SimplePollId, data.EmployeeName);

});