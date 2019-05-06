// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Events +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

let starWarsPeople = null;
let starWarsPlanets = null;
let searchResults = [];

function getData(dataURL, final = [])
{
    let promise = new Promise( (resolve, reject) => 
        {
            $.ajax(
                {
                    url: dataURL,
                    success: async function(result)
                    {
                        if(final.length === 0)
                            final.push(...result.results);

                        if(result.next !== null)
                        {
                            let data = await getData(result.next, final);
                            final.push(...data);
                            if(final.length < result.count)
                                resolve(result.results);
                            else
                            {
                                resolve(final);
                                final = [];
                            }
                        }
                        else
                        {
                            resolve(result.results);
                        }
                    },
                    error: function(result)
                    {
                        reject(result);
                    }
                }
            )// end of ajax
        } );//end of promise

    return promise;
}

function fetchData(url, finalResult = [])
{
    let promise = fetch(url).
        then(result => result.json()).
        then(result => {
            if(result.next !== null)
            {
                finalResult.push(...result.results);
                return fetchData(result.next, finalResult);
            }
            else
            {
                finalResult.push(...result.results);
                return finalResult;
            }
        });
    return promise;
}


//  ++++++++++++++++++++++ Get People +++++++++++++++++++++++++++++++++
$("#getPeople").on("click", function(event) {
    
    clearTableData();
    showPlanetsTable(false);
    noResultsFound(false);
    showLogo(false);
    searchResults = [];

    if(starWarsPeople === null)
    {
        showProgess(true);
        
        let promise = getData("https://swapi.co/api/people/");

        promise.then( (result) => {
                                        showProgess(false);
                                        starWarsPeople = populateTable(result);
                                        showPeopleTable(true);
                                  }
                    );
    }
    else
    {
        populateTable(starWarsPeople);
        showPeopleTable(true);
    }

});

//  ++++++++++++++++++++++ Get Planets +++++++++++++++++++++++++++++++++
$("#getPlanets").on("click", function(event) {

    // Clear page
    clearTableData();
    showPeopleTable(false);
    noResultsFound(false);
    showLogo(false);
    searchResults = [];

    if(starWarsPlanets === null)
    {
        showProgess(true);

        // let promise = getData("https://swapi.co/api/planets/");
        let promise = fetchData("https://swapi.co/api/planets/");
        
        promise.then( (result) => {
                                    showProgess(false);
                                    starWarsPlanets = populateTable(result);
                                    showPlanetsTable(true);
                                  }   
                    );
    }
    else
    {
        populateTable(starWarsPlanets);
        showPlanetsTable(true);
    }
    
});

//  ++++++++++++++++++++++++++ Home +++++++++++++++++++++++++++++++++
$("#goHome").on("click", function(event) {

    // Clear page
    clearTableData();
    showPlanetsTable(false);
    showPeopleTable(false);
    noResultsFound(false);
    showLogo(true);
});

//  ++++++++++++++++++++++ Search ++++++++++++++++++++++++++++++++++++
$("#search").on("click", async function(event) {

    // Clear page
    clearTableData();
    showPlanetsTable(false);
    showPeopleTable(false);
    showLogo(false);
    noResultsFound(false);
    searchResults = [];

    showProgess(true);

    let search_text = $(".form-control").val();
    $(".form-control").val("");
    
    if(search_text === "")
    {
        showProgess(false);
        showLogo(true);
        return;
    }
    
    if(starWarsPeople === null)
        starWarsPeople = await getData("https://swapi.co/api/people/").then(result => result);

    if(starWarsPlanets === null)
        starWarsPlanets = await fetchData("https://swapi.co/api/planets/").then(result => result);

    let foundPeople = parsePeople(starWarsPeople).filter((elem) => {

        let  found = false;
        for (const key in elem) {
            if (elem.hasOwnProperty(key)) {
                const element = new String(elem[key]);
                if(element.indexOf(search_text) > -1)
                    found = true;
            }
        }
        return found;

    });

    let foundPlanets = parsePlanets(starWarsPlanets).filter((elem) => {

        let  found = false;
        for (const key in elem) {
            if (elem.hasOwnProperty(key)) {
                const element = new String(elem[key]);
                if(element.indexOf(search_text) > -1)
                    found = true;
            }
        }
        return found;

    }); 
    
    showProgess(false); 

    if(foundPeople.length > 0)
    {
        searchResults.push(...foundPeople);
        populateTable(foundPeople);
    }

    if(foundPlanets.length > 0)
    {
        searchResults.push(...foundPlanets);
        populateTable(foundPlanets);
    }
    
    if(foundPeople.length > 0)
        showPeopleTable(true);
    if(foundPlanets.length > 0)
        showPlanetsTable(true);

    if(foundPeople.length === 0 && foundPlanets.length === 0)
        noResultsFound(true);
})

//++++++++++++++++++++++++++++++++++++++ Sort people events ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
let sortNameAsc = true;
$("#people th:nth-child(1)").on("dblclick", (event) =>
{   
    let sorted = [];

    if(searchResults.length > 0)
        sorted = searchResults;
    else
        sorted = starWarsPeople;

    if(sortNameAsc)
    {      
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.name <= e2.name) 
                                                return -1;
                                            return 1;
                                         } );
        sortNameAsc = !sortNameAsc;
    }
    else
    {   
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.name >= e2.name)
                                                return -1;
                                            return 1;
                                         } );
        sortNameAsc = !sortNameAsc;
    }

    clearTableData();
    populateTable(sorted);
});

let sortGenderDesc = false;
$("#people th:nth-child(2)").on("dblclick", (event) =>
{
    let sorted = [];

    if(searchResults.length > 0)
        sorted = searchResults;
    else
        sorted = starWarsPeople;

    if(sortGenderDesc)
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.gender !== undefined && e2.gender === undefined)
                                                return -1;
                                            
                                            if(e1.gender === undefined && e2.gender !== undefined)
                                                return 1;

                                            if(e1.gender >= e2.gender) 
                                                return -1;
                                            return 1;
                                        } );
        sortGenderDesc = !sortGenderDesc;
    }
    else
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.gender !== undefined && e2.gender === undefined)
                                                return -1;
                                            
                                            if(e1.gender === undefined && e2.gender !== undefined)
                                                return 1;
                                            
                                            if(e1.gender <= e2.gender) 
                                                return -1;
                                            return 1;
                                        } );
        sortGenderDesc = !sortGenderDesc;
    }

    clearTableData();
    populateTable(sorted);
});

let sortDobAsc = true;
$("#people th:nth-child(3)").on("dblclick", (event) =>
{
    let sorted = [];

    if(searchResults.length > 0)
        sorted = searchResults;
    else
        sorted = starWarsPeople;
        
    if(sortDobAsc)
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.birth_year !== undefined && e2.birth_year === undefined)
                                                return -1;
                                            
                                            if(e1.birth_year === undefined && e2.birth_year !== undefined)
                                                return 1;

                                            if(e1.birth_year >= e2.birth_year) 
                                                return -1;
                                            return 1;
                                        } );
        sortDobAsc = !sortDobAsc;
    }
    else
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.birth_year !== undefined && e2.birth_year === undefined)
                                                return -1;
                                            
                                            if(e1.birth_year === undefined && e2.birth_year !== undefined)
                                                return 1;

                                            if(e1.birth_year <= e2.birth_year) 
                                                return -1;
                                            return 1;
                                        } );
        sortDobAsc = !sortDobAsc;
    }

    clearTableData();
    populateTable(sorted);
});

let sortHeightAsc = true;
$("#people th:nth-child(4)").on("dblclick", (event) =>
{
    let sorted = [];

    if(searchResults.length > 0)
        sorted = searchResults;
    else
        sorted = starWarsPeople;

    if(sortHeightAsc)
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.height !== undefined && e2.height === undefined)
                                                return -1;
                                            
                                            if(e1.height === undefined && e2.height !== undefined)
                                                return 1;

                                            let n1 = Number(e1.height);
                                            let n2 = Number(e2.height);

                                            if(Number.isNaN(n1) && !isNaN(n2))
                                                return 1;

                                            if(!isNaN(n1) && Number.isNaN(n2))
                                                return -1;

                                            if(n1 <= n2) 
                                                return -1;
                                            return 1;
                                        } );
        sortHeightAsc = !sortHeightAsc;
    }
    else
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.height !== undefined && e2.height === undefined)
                                                return -1;
                                            
                                            if(e1.height === undefined && e2.height !== undefined)
                                                return 1;

                                            let n1 = Number(e1.height);
                                            let n2 = Number(e2.height);

                                            if(Number.isNaN(n1) && !isNaN(n2))
                                                return 1;

                                            if(!isNaN(n1) && Number.isNaN(n2))
                                                return -1;

                                            if(n1 >= n2) 
                                                return -1;
                                            return 1;
                                        } );
        sortHeightAsc = !sortHeightAsc;
    }

    clearTableData();
    populateTable(sorted);
});

let sortMassAsc = true;
$("#people th:nth-child(5)").on("dblclick", (event) =>
{
    let sorted = [];

    if(searchResults.length > 0)
        sorted = searchResults;
    else
        sorted = starWarsPeople;
    
    if(sortMassAsc)
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.mass !== undefined && e2.mass === undefined)
                                                return -1;
                                            
                                            if(e1.mass === undefined && e2.mass !== undefined)
                                                return 1;

                                            let n1 = Number(e1.mass);
                                            let n2 = Number(e2.mass);

                                            if(Number.isNaN(n1) && !isNaN(n2))
                                                return 1;

                                            if(!isNaN(n1) && Number.isNaN(n2))
                                                return -1;

                                            if(n1 <= n2) 
                                                return -1;
                                            return 1;
                                        } );
        sortMassAsc = !sortMassAsc;
    }
    else
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.mass !== undefined && e2.mass === undefined)
                                                return -1;
                                            
                                            if(e1.mass === undefined && e2.mass !== undefined)
                                                return 1;

                                            let n1 = Number(e1.mass);
                                            let n2 = Number(e2.mass);

                                            if(Number.isNaN(n1) && !isNaN(n2))
                                                return 1;

                                            if(!isNaN(n1) && Number.isNaN(n2))
                                                return -1;

                                            if(n1 >= n2) 
                                                return -1;
                                            return 1;
                                        } );
        sortMassAsc = !sortMassAsc;
    }

    clearTableData();
    populateTable(sorted);
});

//++++++++++++++++++++++++++++++++++++++ Sort planets events ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

$("#planets th:nth-child(1)").on("dblclick", (event) =>
{
    let sorted = [];

    if(searchResults.length > 0)
        sorted = searchResults;
    else
        sorted = starWarsPlanets;

    if(sortNameAsc)
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.name <= e2.name) 
                                                return -1;
                                            return 1;
                                         } );
        sortNameAsc = !sortNameAsc;
    }
    else
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.name >= e2.name)
                                                return -1;
                                            return 1;
                                         } );
        sortNameAsc = !sortNameAsc;
    }

    clearTableData();
    populateTable(sorted);
});

let sortPlanetDiameterAsc = true;
$("#planets th:nth-child(2)").on("dblclick", (event) =>
{
    let sorted = [];

    if(searchResults.length > 0)
        sorted = searchResults;
    else
        sorted = starWarsPlanets;
    
    if(sortPlanetDiameterAsc)
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.diameter !== undefined && e2.diameter === undefined)
                                                return -1;
                                            
                                            if(e1.diameter === undefined && e2.diameter !== undefined)
                                                return 1;

                                            let n1 = Number(e1.diameter);
                                            let n2 = Number(e2.diameter);

                                            if(Number.isNaN(n1) && !isNaN(n2))
                                                return 1;

                                            if(!isNaN(n1) && Number.isNaN(n2))
                                                return -1;

                                            if(n1 <= n2) 
                                                return -1;
                                            return 1;
                                        } );
        sortPlanetDiameterAsc = !sortPlanetDiameterAsc;
    }
    else
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.diameter !== undefined && e2.diameter === undefined)
                                                return -1;
                                            
                                            if(e1.diameter === undefined && e2.diameter !== undefined)
                                                return 1;

                                            let n1 = Number(e1.diameter);
                                            let n2 = Number(e2.diameter);

                                            if(Number.isNaN(n1) && !isNaN(n2))
                                                return 1;

                                            if(!isNaN(n1) && Number.isNaN(n2))
                                                return -1;

                                            if(n1 >= n2)
                                                return -1;
                                            return 1;
                                        } );
        sortPlanetDiameterAsc = !sortPlanetDiameterAsc;
    }

    clearTableData();
    populateTable(sorted);
});

let sortPlanetClimateAsc = true;
$("#planets th:nth-child(3)").on("dblclick", (event) =>
{
    let sorted = [];

    if(searchResults.length > 0)
        sorted = searchResults;
    else
        sorted = starWarsPlanets;
    
    if(sortPlanetClimateAsc)
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.climate !== undefined && e2.climate === undefined)
                                                return -1;
                                            
                                            if(e1.climate === undefined && e2.climate !== undefined)
                                                return 1;

                                            if(e1.climate <= e2.climate) 
                                                return -1;
                                            return 1;
                                        } );
        sortPlanetClimateAsc = !sortPlanetClimateAsc;
    }
    else
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.climate !== undefined && e2.climate === undefined)
                                                return -1;
                                            
                                            if(e1.climate === undefined && e2.climate !== undefined)
                                                return 1;

                                            if(e1.climate >= e2.climate)
                                                return -1;
                                            return 1;
                                        } );
        sortPlanetClimateAsc = !sortPlanetClimateAsc;
    }

    clearTableData();
    populateTable(sorted);
});

let sortPlanetTerrainAsc = true;
$("#planets th:nth-child(4)").on("dblclick", (event) =>
{
    let sorted = [];

    if(searchResults.length > 0)
        sorted = searchResults;
    else
        sorted = starWarsPlanets;
    
    if(sortPlanetTerrainAsc)
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.terrain !== undefined && e2.terrain === undefined)
                                                return -1;
                                            
                                            if(e1.terrain === undefined && e2.terrain !== undefined)
                                                return 1;

                                            if(e1.terrain <= e2.terrain) 
                                                return -1;
                                            return 1;
                                        } );
        sortPlanetTerrainAsc = !sortPlanetTerrainAsc;
    }
    else
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.terrain !== undefined && e2.terrain === undefined)
                                                return -1;
                                            
                                            if(e1.terrain === undefined && e2.terrain !== undefined)
                                                return 1;

                                            if(e1.terrain >= e2.terrain)
                                                return -1;
                                            return 1;
                                        } );
        sortPlanetTerrainAsc = !sortPlanetTerrainAsc;
    }

    clearTableData();
    populateTable(sorted);
});

let sortPlanetRotationPeriodAsc = true;
$("#planets th:nth-child(5)").on("dblclick", (event) =>
{
    let sorted = [];

    if(searchResults.length > 0)
        sorted = searchResults;
    else
        sorted = starWarsPlanets;
    
    if(sortPlanetRotationPeriodAsc)
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.rotation_period !== undefined && e2.rotation_period === undefined)
                                                return -1;
                                            
                                            if(e1.rotation_period === undefined && e2.rotation_period !== undefined)
                                                return 1;

                                            let n1 = Number(e1.rotation_period);
                                            let n2 = Number(e2.rotation_period);

                                            if(Number.isNaN(n1) && !isNaN(n2))
                                                return 1;

                                            if(!isNaN(n1) && Number.isNaN(n2))
                                                return -1;

                                            if(n1 <= n2) 
                                                return -1;
                                            return 1;
                                        } );
        sortPlanetRotationPeriodAsc = !sortPlanetRotationPeriodAsc;
    }
    else
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.rotation_period !== undefined && e2.rotation_period === undefined)
                                                return -1;
                                            
                                            if(e1.rotation_period === undefined && e2.rotation_period !== undefined)
                                                return 1;

                                            let n1 = Number(e1.rotation_period);
                                            let n2 = Number(e2.rotation_period);

                                            if(Number.isNaN(n1) && !isNaN(n2))
                                                return 1;

                                            if(!isNaN(n1) && Number.isNaN(n2))
                                                return -1;

                                            if(n1 >= n2)
                                                return -1;
                                            return 1;
                                        } );
        sortPlanetRotationPeriodAsc = !sortPlanetRotationPeriodAsc;
    }

    clearTableData();
    populateTable(sorted);
});

let sortPlanetPopulationeAsc = true;
$("#planets th:nth-child(6)").on("dblclick", (event) =>
{
    let sorted = [];

    if(searchResults.length > 0)
        sorted = searchResults;
    else
        sorted = starWarsPlanets;
    
    if(sortPlanetPopulationeAsc)
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.population !== undefined && e2.population === undefined)
                                                return -1;
                                            
                                            if(e1.population === undefined && e2.population !== undefined)
                                                return 1;

                                            let n1 = Number(e1.population);
                                            let n2 = Number(e2.population);

                                            if(Number.isNaN(n1) && !isNaN(n2))
                                                return 1;

                                            if(!isNaN(n1) && Number.isNaN(n2))
                                                return -1;

                                            if(n1 >= n2) 
                                                return -1;
                                            return 1;
                                        } );
        sortPlanetPopulationeAsc = !sortPlanetPopulationeAsc;
    }
    else
    {
        sorted = sorted.sort( (e1,e2) => { 
                                            if(e1.population !== undefined && e2.population === undefined)
                                                return -1;
                                            
                                            if(e1.population === undefined && e2.population !== undefined)
                                                return 1;

                                            let n1 = Number(e1.population);
                                            let n2 = Number(e2.population);

                                            if(Number.isNaN(n1) && !isNaN(n2))
                                                return 1;

                                            if(!isNaN(n1) && Number.isNaN(n2))
                                                return -1;

                                            if(n1 <= n2)
                                                return -1;
                                            return 1;
                                        } );
        sortPlanetPopulationeAsc = !sortPlanetPopulationeAsc;
    }

    clearTableData();
    populateTable(sorted);
});

// +++++++++++++++++++++++++++++++++++++++++++++++++++++++ Drag and Close details window ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

let left;
let _top;
let currentMousePosLeft;
let currentMousePosTop;

function detailsMouseDown(event)
{
    let details = $("#details");
    left = Number(details.css("left").substring(0, details.css("left").indexOf("px")));
    _top = Number(details.css("top").substring(0, details.css("top").indexOf("px")));
    currentMousePosLeft = event.pageX;
    currentMousePosTop = event.pageY;
};

function detailsMouseUp(event)
{
    left = undefined;
    _top = undefined;
    currentMousePosLeft = undefined;
    currentMousePosTop = undefined;
};

function detailsMouseMove(event)
{
    if(left !== undefined && _top !== undefined)
    {
        let details = $("#details");
        details.css("left", event.pageX - (currentMousePosLeft - left) + "px");
        details.css("top", event.pageY - (currentMousePosTop - _top) + "px");
    }
};

$("#details > button").on("click", function(event)
{
    showDetailsDialog(false);
});

// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++ Show people/planets details +++++++++++++++++++++++++++++++++++++++++++++++++++++++

function showDetails(event)
{   
    $(this).parent().children("tr").off("click");
    let display = $(`#details`).css("display");
    if(display === "none")
    {
        let name = $(this).find(":nth-child(1)").text();
        let type = $(this).attr("type");
        let promise = fetch(`https://swapi.co/api/${type}/?search=${name}`).
                        then(result => result.json()).
                            then(result => 
                            {
                                if(result.results.length > 0)
                                {
                                    if(isPeople(result.results[0]))
                                        populatePeopleDetails(result.results[0]);
                                    
                                    if(isPlanet(result.results[0]))
                                        populatePlanetDetails(result.results[0]);

                                    showDetailsDialog(true);
                                }
                                
                                $(this).parent().children("tr").on("click", showDetails);
                            });
        }
}

function showDetailsDialog(show)
{   
    if(show)
    {
        let width = $(window).innerWidth();
        let height = $(window).innerHeight();
        let details = $("#details");
        details.css("top", parseInt(height/5) + "px");
        details.css("left", parseInt(width/4) + "px");
        let detailsModal = $("#detailsModal");
        detailsModal.css("width", $(document).width() + "px");
        detailsModal.css("height", $(document).height() + "px");
        detailsModal.show();
    }
    else
    {
        let details = $("#details");
        details.find(":not(button)").remove();
        $("#detailsModal").hide();
    }
}

function populatePeopleDetails(people)
{
    let table = $(`<table>
                    <thead>
                    </thead>
                    <tbody>
                    </tbody>
                </table>`);

    for(prop in people)
    {   
        let row = $(`<tr>`);

        if(prop === "name")
        {
            let cell = $(`<th colspan="2">`);
            cell.text(people.name);
            row.append(cell);
            table.find(`thead`).append(row);
        }
        else if(prop === "films")
        {
            let cell = $(`<td colspan="2">`);
            cell.text("Movies");
            row.append(cell);
            table.find(`tbody`).append(row);

            row = $(`<tr>`);
            cell = $(`<td colspan="2">`);
            let list = $(`<ul>`);
            let i = 1;
            for(let item of people[prop])
            {
                let li = $(`<li>`);
                li.html(`<a href="${item}">Movie ${i++}</a>`);
                list.append(li);
            }
            
            cell.append(list);
            row.append(cell);

            table.find(`tbody`).append(row);
        }
        else if(prop !== "films" && prop !== "species" && prop !== "vehicles" &&
                prop !== "starships" && prop !== "created" && prop !== "edited" &&
                prop !== "url" && prop !== "homeworld")
        {
            let cell = $(`<td>`);
            cell.text(parseProperty(prop));
            row.append(cell);

            cell = $(`<td>`);
            cell.text(parseProperty(people[prop]));
            row.append(cell);

            table.find(`tbody`).append(row);
        }
    }

    $("#details").append(table);
    $("#details tbody tr a").on("click", showMovieDetails);
    $("#details thead th").on("mousedown", detailsMouseDown);
    $("#details thead th").on("mouseup", detailsMouseUp);
    $("#details thead th").on("mousemove", detailsMouseMove);
}

function showMovieDetails(event)
{
    event.preventDefault();
    let movie = `#${$(this).text().replace(new RegExp(" ", "g"), "_")}`;
    let movieDet = $(movie.toString());
    if(movieDet.length === 0)
    {
        $(this).off("click");
        $(this).on("click", (even) => {even.preventDefault()});

        fetch(event.target.href).
            then(result => result.json()).
                then(result => 
                {
                    let row = $(this).parent();
                    let movieDetails = $(`<div id="${$(this).text().replace(new RegExp(" ", "g"), "_")}" class="movieDetails">`);
                    movieDetails.hide();
                    movieDetails.html(`<b>Title:</b> ${result.title} <br>
                            <b>Synopsis:</b> ${result.opening_crawl} <br>
                            <b>Producer:</b> ${result.producer} <br>
                            <b>Director:</b> ${result.director}`);
                    row.append(movieDetails);
                    movieDetails.fadeIn(1000);
                    $(this).off("click");
                    $(this).on("click", showMovieDetails);
                });
    }
    else
    {
        let isShown = movieDet.css("display");
        if(isShown !== "none")
            movieDet.fadeOut(1000);
        else
            movieDet.fadeIn(1000);
    }
}

function populatePlanetDetails(planet)
{
    let table = $(`<table>
                    <thead>
                    </thead>
                    <tbody>
                    </tbody>
                </table>`);

    for(prop in planet)
    {   
        let row = $(`<tr>`);

        if(prop === "name")
        {
            let cell = $(`<th colspan="2">`);
            cell.text(planet.name);
            row.append(cell);
            table.find(`thead`).append(row);
        }
        else if(prop !== "films" && prop !== "created" && prop !== "edited" &&
                prop !== "url" && prop !== "residents")
        {
            let cell = $(`<td>`);
            cell.text(parseProperty(prop));
            row.append(cell);

            cell = $(`<td>`);
            cell.text(parseProperty(planet[prop]));
            row.append(cell);

            table.find(`tbody`).append(row);
        }
    }

    $("#details").append(table);
    $("#details thead th").on("mousedown", detailsMouseDown);
    $("#details thead th").on("mouseup", detailsMouseUp);
    $("#details thead th").on("mousemove", detailsMouseMove);
}
// ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++