"use strict";

//import { signalR } from "../lib/microsoft/signalr/dist/browser/signalr";

var connection=new signalR.HubConnectionBuilder().withUrl("/MeasurementHub").build();

document.getElementById("connectButton").addEventListener("click", function (event) {

    
    connection.start().then(console.log("Started"));
    //document.getElementById("connectButton").disabled = true;
});

connection.on("ReceiveMessage", function (user, message) {
    console.log(message);
    let msg = JSON.parse(message);

    var ul = document.createElement("ul");

    for (var propertyName in msg) {
        var li = ul.createElement("li");
        li.textContent = propertyName + ": " + message.propertyName;
    }
    document.getElementById("measurements").appendChild(ul);
});