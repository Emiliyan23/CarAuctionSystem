"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/auctionHub").build();

connection.on("ReceiveBid", function (BidTime, BidderId, BidderUsername, BidAmount) {

    console.log(BidTime);
    var bidList = $("#bidList");
    if (bidList.find(".list-group-item").length === 1) {
        bidList.find(".list-group-item").remove();
        bidList.append('<li class="list-group-item">Bid count: 1</li>');
    } else {
        var bidCountElement = bidList.find(".list-group-item:contains('Bid count')");
        var bidCount = parseInt(bidCountElement.text().match(/\d+/)[0]) + 1;
        bidCountElement.text("Bid count: " + bidCount);
    }

    bidList.append('<li class="list-group-item">' + BidTime + ' ' +
        '<a href="/User/Profile/' + BidderId + '">' + BidderUsername + '</a> - ' + 
        BidAmount + '</li>');
});

connection.start();