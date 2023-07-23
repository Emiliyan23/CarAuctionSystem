function statistics() {
    $('#statistics_btn').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();

        $.get('https://localhost:7156/api/statistics', function (data) {
            $('#auctions_count').text(data.auctionsCount + " Auctions");
            $('#sales_count').text(data.salesCount + " Cars sold");
            $('#bids_count').text(data.bidsCount + " Total bids");

            $('#statistics_box').removeClass('d-none');
            $('#statistics_btn').hide();
        });
	});
}