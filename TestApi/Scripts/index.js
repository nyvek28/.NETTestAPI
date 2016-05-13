$(function () {
    $.getJSON('/api/contact', function (contactsJsonPayload) {
        $(contactsJsonPayload).each(function (i, item) {
            $('#contacts').append('<li>' + item.Name + '</li>');
        });
    });

});

$('#saveContact').click(function () {
    $.post('/api/contact',
            $('#contact-form').serialize(),
            function (value) {
                $('#contacts').append('<li>' + value.Name + '</li>');
            },
            'json'
            );
});