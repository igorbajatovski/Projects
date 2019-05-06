// +++++++++++++++++++++++++++++++++++++++++++++ Display ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

function clearTableData()
{   
    let tableBody = $("#table tbody");
    let rows = tableBody.children();
    if(rows.length > 0)
        rows.remove();
}

function showProgess(show)
{
    if(show)
    {
        $("#spinner").append(`<img src="assets/spinner3.gif">`);
    }
    else
    {
        let progress = $("#spinner").children();
        if(progress.length > 0)
            progress.remove();
    }
}

function showLogo(show)
{
    let logo = $(".logo");
    if(show)
        logo.show();
    else
        logo.hide();
}

function noResultsFound(show)
{
    if(show)
    {
        $("#spinner").append(`<h2>No results found</h2>`);
    }
    else
    {
        let progress = $("#spinner").children();
        if(progress.length > 0)
            progress.remove();
    }
}

function showPlanetsTable(visible)
{
    let table = $("#table");
    let secondRowHeader = $("#table #planets");

    if(visible)
    {
        table.removeClass("display-none");
        secondRowHeader.removeClass("display-none");
    }
    else
    {
        table.addClass("display-none");
        secondRowHeader.addClass("display-none");
    }
}

function showPeopleTable(visible)
{
    let table = $("#table");
    let firstRowHeader = $("#table #people");

    if(visible)
    {
        table.removeClass("display-none");
        firstRowHeader.removeClass("display-none");
    }
    else
    {
        table.addClass("display-none");
        firstRowHeader.addClass("display-none");
    }
}

function populateTable(data)
{
    let tableBody = $("#table tbody");

    for (const item of data)
    {   
        let newRow = $(`<tr>`);

        // if planet
        if(isPlanet(item))
        {
            newRow.append(`<td>${item.name}</td>
                            <td>${item.diameter}</td>
                            <td>${item.climate}</td>
                            <td>${item.terrain}</td>
                            <td>${item.rotation_period}</td>
                            <td>${item.population}</td>`);
            newRow.attr("type", "planets");
        }

        // if people
        if(isPeople(item))
        {
            newRow.append(`<td>${item.name}</td>
                            <td>${item.gender}</td>
                            <td>${item.birth_year}</td>
                            <td>${item.height}</td>
                            <td>${item.mass}</td>`);
            newRow.attr("type", "people");
        }

        tableBody.append(newRow);

    }

    $("#table tbody tr").off("click");
    $("#table tbody tr").on("click", showDetails);

    return data;
}
// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++