"use strict";

var connection = new signalR
    .HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message, userId) {
    var li = document.createElement("li");
    var userProfileButton = document.createElement("button");
    var replyButton = document.createElement("button");

    userProfileButton.innerText = "View Profile";
    userProfileButton.classList.add("user-profile-button");
    userProfileButton.setAttribute("data-user-id", userId);

    replyButton.innerText = "Reply";
    replyButton.classList.add("reply-button");
    replyButton.setAttribute("data-user-id", userId);

    li.textContent = `${user} says: ${message}`;
    li.appendChild(userProfileButton);
    li.appendChild(replyButton);

    document.getElementById("messagesList").appendChild(li);
});


connection.on("ReceiveAdminReply", function (adminReply) {
        var li = document.createElement("li");
        document.getElementById("messagesList").appendChild(li);
        li.textContent = `Admin says ${adminReply}`;
});



connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("chat-input").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("messagesList").addEventListener("click", function (event) {
    if (event.target && event.target.classList.contains("reply-button")) {
        const button = event.target;
        console.log(button);
        console.log(button.parentElement);
        const textElement = document.getElementById('chat-input');
        const userId = button.getAttribute("data-user-id");
        const adminReply = textElement.value;

        // Отправить ответ администратора конкретному пользователю с использованием SignalR.
        connection.invoke("SendAdminReply", userId, adminReply).catch(function (err) {
            return console.error(err.toString());
        });

        // Очистить поле ввода ответа после отправки ответа.
        button.parentElement.querySelector(".admin-reply").value = "";
    }
});