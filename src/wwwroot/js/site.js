// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

var connection = new signalR.HubConnectionBuilder()
    .configureLogging("trace")
    .withUrl("/jabbr")
    .build();

connection.start();