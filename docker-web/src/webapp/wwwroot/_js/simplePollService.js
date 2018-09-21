function simplePollService() {

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
        var simplePollOptionId = '0001-' + optionId;
        return {
            "Id": id,
            "SimplePollOptionId": simplePollOptionId,
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

    var service = {
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
        addAnswerToSimplePollOption: function(id) {
            var dfd = $.Deferred();
            setTimeout(function() {
                dfd.resolve({});
            }, 200);
            return dfd.promise();
        },
    };

    return service;
};