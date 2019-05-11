// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Write your JavaScript code.
const rateMovie = async (name, rating) => {
    const response = await fetch('/Movie/Rate', {
        body: JSON.stringify({ name, rating, }),
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            dataType: 'application/json',
        }
    })

    const responseParsedFromJSON = await response.json();

    return responseParsedFromJSON;
};


$('.rating-dropdown .dropdown-item').on('click', async (ev) => {
    const ratingSelected = $(ev.target).html();
    const movieName = $(ev.target).attr('data-name');
    try {
        const updatedMovie = await rateMovie(movieName, ratingSelected);
        $('.rating-dropdown .dropdown-toggle').html(updatedMovie.rating);
    } catch (err) {
        alert('There was an error submitting your request!');
    }
})

//marks textarea of comments default value to empty
 $(function () {
        $("#Comments").html("");
    });