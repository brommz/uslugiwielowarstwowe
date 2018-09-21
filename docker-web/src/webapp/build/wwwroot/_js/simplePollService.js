function simplePollService() {

    var service = {
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
                data: {  }
            });
        },
    };

    return service;
};

