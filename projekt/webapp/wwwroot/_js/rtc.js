function simplePollsRTC() {
    var ortcClient;

    return {
        connectTo: function() {
            ortcClient = RealtimeMessaging.createClient();
            ortcClient.setClusterUrl('https://ortc-developers.realtime.co/server/ssl/2.1/');
            ortcClient.connect('0e6aUZ', 'genTestTokenRandomHehe');
        },
        subscribe: function(simplePollId) {
            ortcClient.onConnected = function (ortc) {
                console.log("Connected to " + ortcClient.getUrl());

                ortcClient.subscribe(simplePollId, true, function (ortc, channel, message) {
                    alert(message);
                });
            };
        },
        sendPollUpdated: function (simplePollId, employeeName) {
            var myMessage = {
                employeeName: employeeName
            };

            ortcClient.send(simplePollId, JSON.stringify(myMessage));   
        }
    }
};