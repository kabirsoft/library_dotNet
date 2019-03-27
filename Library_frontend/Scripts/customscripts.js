$(function () {
    function DisplayResult1(call, data) {
        $('#result').append("<strong>" + call + "<strong>" + "<br/>");

        $.each(data, function (i, item) {

            $('#result').append(JSON.stringify(item));
            $('#result').append("<br/>");
        });
    };

    function DisplayResult2(call, data) {
        $('#result').append("<strong>" + call + "<strong>" + "<br/>");

        $('#result').append(JSON.stringify(data));
        $('#result').append("<br/>");

    };
    var serviceUrl = "http://localhost:51288/api"  //webservice's url

    $('#GetAll').on('click', function () {
        $.ajax({
            url: serviceUrl + "/books",
            Method: 'GET',
            success: function (data) {
                DisplayResult1("Get all:", data);
            }
        });
    });

    $('#GetById').on('click', function () {
        var bookId = $('#id').val();
        $.ajax({
            url: serviceUrl + '/books/ ' + bookId,
            method: 'GET',
            success: function (data) {
                DisplayResult2("Book by id:", data);
            }
        });
    });


    $('#AddBook').on('click', function () {
        var inputData = $('input').serialize();
        $.ajax({
            url: serviceUrl + '/books/',
            method: 'POST',
            data: inputData,
            success: function (data) {
                DisplayResult2("Add Book", data);
            }
        });
    });


    $('#UpdateBook').on('click', function () {
        var inputData = $('input').serialize();
        var bookId = $('#id').val();
        $.ajax({
            url: serviceUrl + '/books/' + bookId,
            method: 'PUT',
            data: inputData,
            success: function (data) {
                DisplayResult1("Updated list:", data);
            }
        });
    });


    $('#AddCost').on('click', function () {
        var bookid = $('#id').val();
        var inputdata = $("#FormCost").serialize();

        $.ajax({
            url: serviceUrl + '/books/addcost/' + bookid,
            method: 'PUT',
            data: inputdata,
            success: function (data) {
                DisplayResult2("Cost added", data);
            }
        });
    });



    //put books id in the input form
    $('#GetAuthorById').on('click', function () {
        var bookId = $('#id').val();
        $.ajax({
            url: serviceUrl + '/books/authorname/' + bookId,
            method: 'GET',
            success: function (data) {
                DisplayResult2("Author name: ", data);
            }
        });
    });

    //put book's author name in the author field in input form.
    $('#GetBooksByAuthor').on('click', function () {
        var author = $('#author').val();
        $.ajax({
            url: serviceUrl + '/books/author/' + author,
            method: 'GET',
            success: function (data) {
                DisplayResult2("Get books by author name: ", data);
            }
        });
    });

    //put book's author name in the author field, year in year's field in input form.
    $('#GetBooksByAuthorAndYear').on('click', function () {
        var author = $('#author').val();
        var year = $('#publicationyear').val();
        $.ajax({
            url: serviceUrl + '/books/author/' + author + '/year/' + year,
            method: 'GET',
            success: function (data) {
                DisplayResult2("Get books by author and year: ", data);
            }
        });
    });

});