let connection = null;

setupConnection = () => {
    connection = new signalR.HubConnectionBuilder()
    .withUrl("/auctionHub")
    .build();

    connection.on()
};