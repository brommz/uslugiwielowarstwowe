function simplePollService() {

    // dla testów w fakeService
    var simplePollUpdateModel = {
        "Type": 0,
        "Text": 'Przykladowy tekst update model'
    };

    var simplePollOption = function(optionId) {
        var id = '55445454545' + optionId;
        var text = 'Opcja_' + optionId;
        return {
            "Id": id,
            "Text": text
        };
    };

    var simplePollAnswer = function(answerId, optionId, employeeName) {
        var id = '55445454545' + optionId;
        return {
            "Id": id,
            "SimplePollOptionId": optionId,
            "EmployeeName": employeeName
        };
    };

    var simplePoll = {
        "Id": '656-asd54-rt5-6565e6r-5445W-00000',
        "Type": 0,
        "Text": 'Jakis przykladowy tekst pobrany',
        "Options": [simplePollOption(123), simplePollOption(789)]
    };

    var simplePollAnswerUpdateModel = {
        "SimplePollId": '65565656560',
        "SimplePollOptionId": '5545544545',
        "EmployeeName": "HenioZdzisiowy"
    };

    var fakeService = {
        action1: function() {
            return $.ajax({
                url: '',
                method: 'GET',
                dataType: 'json',
            });
        },
        action2: function() {
            return $.ajax({
                url: '',
                method: 'POST',
                dataType: 'json',
                data: {}
            });
        },
        addSimplePoll: function(data) {
            var dfd = $.Deferred();
            setTimeout(function() {
                dfd.resolve(simplePoll);
            }, 200);
            return dfd.promise();
        },
        addOption: function(data) {
            var dfd = $.Deferred();
            setTimeout(function() {
                dfd.resolve({});
            }, 200);
            return dfd.promise();
        },
        getSimplePoll: function(id) {
            var dfd = $.Deferred();
            setTimeout(function() {
                dfd.resolve(simplePoll);
            }, 200);
            return dfd.promise();
        },
        addAnswerToSimplePollOption: function (data) {
            var dfd = $.Deferred();
            setTimeout(function() {
                dfd.resolve({});
            }, 200);
            return dfd.promise();
        },
        getAnswersForSimplePoll: function (id) {
            var answers = {
                "Answers": [
                    simplePollAnswer(0, '55445454545789', 'Jozfa'),
                    simplePollAnswer(0, '55445454545123', 'Wicio')
                ]
            };

            var dfd = $.Deferred();
            setTimeout(function () {
                dfd.resolve(answers);
            }, 200);
            return dfd.promise();
        },
    };

    var service = {
        /*
        action1: function () {
            return $.ajax({
                url: '',
                method: 'GET',
                dataType: 'json',
            });
        },
        action2: function () {
            return $.ajax({
                url: '',
                method: 'POST',
                dataType: 'json',
                data: {}
            });
        },
        */
        addSimplePoll: function (data) {
            return $.ajax({
                url: '/api/SimplePolls/',
                method: 'POST',
                dataType: 'json',
                data: JSON.stringify(data),
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            });
        },
        addOption: function (data) {
            return $.ajax({
                url: '/api/Options/',
                method: 'POST',
                dataType: 'json',
                data: JSON.stringify(data),
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            });
        },
        getSimplePoll: function (id) {
            var url = '/api/SimplePolls/' + id;
            return $.ajax({
                url: url,
                method: 'GET',
                dataType: 'json',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            });
        },
        addAnswerToSimplePollOption: function (data) {
            return $.ajax({
                url: '/api/Answers/',
                method: 'POST',
                dataType: 'json',
                data: JSON.stringify(data),
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            });
        },
        getAnswersForSimplePoll: function (id) {
            var url = '/api/Answers/' + id;
            return $.ajax({
                url: url,
                method: 'GET',
                dataType: 'json',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            });
        },
    };


    //return fakeService; //dla testów
    return service;
};