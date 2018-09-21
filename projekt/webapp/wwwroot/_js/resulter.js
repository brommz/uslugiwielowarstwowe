function querystring(key) {
    var re = new RegExp('(?:\\?|&)' + key + '=(.*?)(?=&|$)', 'gi');
    var r = [],
        m;
    while ((m = re.exec(document.location.search)) != null) r[r.length] = m[1];
    return r;
}

function getResultHtml(singleResult) {
    var templateScript = $("#singleResultTemplate").html();
    var template = Handlebars.compile(templateScript);
    var compiledHtml = template(singleResult);
    return compiledHtml;
}


function connectToRTC() {
    var ortcClient = RealtimeMessaging.createClient();
    ortcClient.setClusterUrl('https://ortc-developers.realtime.co/server/ssl/2.1/');
    ortcClient.connect('0e6aUZ', 'genTestTokenRandomHehe');

    ortcClient.onConnected = function (ortc) {
        console.log("Connected to " + ortcClient.getUrl());

        ortcClient.subscribe('myChannel', true, function (ortc, channel, message) {
            console.log(message);
        });
    };

}

var simplePollService = simplePollService();

var simplePoll = null;
var simplePollId = querystring('id');

var rtc = simplePollsRTC();
rtc.connectTo();
rtc.subscribe(simplePollId);

$('.jsSimplePollId').html(simplePollId);

simplePollService.getSimplePoll(simplePollId)
    .done(function (data) {
        simplePoll = data;

        $('.jsSimplePollText').html(simplePoll.Text);

        var results = [];
        //console.debug(simplePoll.Options[0]);
        for (var i = 0; i < simplePoll.Options.length; i++) {

            var singleResult = {
                OptionId: simplePoll.Options[i].Id,
                OptionText: simplePoll.Options[i].Text,
                EmployeeNames: [],
                AnswersCount: 0
            }

            results.push(singleResult);
        }

        simplePollService.getAnswersForSimplePoll(simplePollId)
            .done(function (data) {
                var answers = data.Answers;
                for (var a = 0; a < answers.length; a++) {
                    var answer = answers[a];

                    for (var i = 0; i < results.length; i++) {
                        if (results[i].OptionId != answer.SimplePollOptionId) {
                            continue;
                        }
                        results[i].EmployeeNames.push(answer.EmployeeName);
                        results[i].AnswersCount++;
                    }
                }

                var $resultsTable = $('.jsSimplePollResults');
                for (var i = 0; i < results.length; i++) {
                    var resultHtml = getResultHtml(results[i]);
                    $resultsTable.append(resultHtml);
                }


            });

    });
