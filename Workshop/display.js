function displayShips(ships)
{
    let display = $("#display");
    display.children().remove();

    for (let i = 0; i < ships.length; ++i) 
    {
        display.append(`
        <table id="${i}" class="ship">
            <tbody>
                
                <tr> <td> <img src="${ships[i].image}"> <td> </tr>
                <tr> <td> <h3> ${ships[i].name} </h3> </td> </tr>
                <tr class="shipRow"> <td> Crew: ${ships[i].crew} </td> </tr>
                <tr class="shipRow"> <td> Fuel: ${ships[i].fuel} </td> </tr>
                <tr class="shipRow"> <td> Hull: ${ships[i].hullStrength} </td> </tr>
                <tr class="shipRow"> <td> Speed: ${ships[i].speed} </td> </tr>
                <tr class="shipRow"> <td> Credits: ${ships[i].credits} </td> </tr>

            </tbody>
        </table>`);


        // Attach click event on the table
        $(`#display #${i}`).on("click", function()
        {
            selectedShip = ships[parseInt($(this).attr("id"))];
            selectedShip.addDockEvent(function(ship) 
            { 
                updateSelectedShip(ship); 
                showDialog(`The ship ${ship.name} has arived at planet ${ship.dockedPlanet.name}`);
            });
            selectedShip.addSpaceEvent(function(spaceEvent, ship)
            {
                updateSelectedShip(ship);
                showDialog(spaceEvent.description);
            });
            displaySelectedShip(selectedShip);
            displayPlanets(planets);
        });
    }    
}

function displaySelectedShip(selectedShip)
{
    let display = $("#display");
    display.children().remove();
    display.append(`<div id="selectedShipDiv"></div>`);
    let selectedShipDiv = $("#selectedShipDiv");
    selectedShipDiv.append(`
    <table id="selectedShip" class="selectedShip">
        <tbody>
            
            <tr> <td> <img src="${selectedShip.image}"> <td> </tr>
            <tr> <td> <h3> ${selectedShip.name} </h3> </td> </tr>
            <tr class="shipRow"> <td> Crew: ${selectedShip.crew} </td> </tr>
            <tr class="shipRow"> <td> Fuel: ${selectedShip.fuel} </td> </tr>
            <tr class="shipRow"> <td> Hull: ${selectedShip.hullStrength} </td> </tr>
            <tr class="shipRow"> <td> Speed: ${selectedShip.speed} </td> </tr>
            <tr class="shipRow"> <td> Credits: ${selectedShip.credits} </td> </tr>

        </tbody>
    </table>`);
}

function updateSelectedShip(selectedShip)
{
    let selectedShipID = $("#selectedShip");
    selectedShipID.find(":nth-child(3)").children().text(`Crew: ${selectedShip.crew}`);
    selectedShipID.find(":nth-child(4)").children().text(`Fuel: ${selectedShip.fuel}`);
    selectedShipID.find(":nth-child(5)").children().text(`Hull: ${selectedShip.hullStrength}`);
    selectedShipID.find(":nth-child(7)").children().text(`Credits: ${selectedShip.credits}`);
}

function displayPlanets(planets)
{
    let display = $("#display");

    for (let i = 0; i < planets.length; ++i) 
    {
        display.append(`
        <table id="${i}" class="planet">
            <tbody>
                
                <tr> <td colspan="2"> <img src="${planets[i].image}"> <td> </tr>
                <tr> <td colspan="2"> <h3> ${planets[i].name} </h3> </td> </tr>
                <tr> <td colspan="2"> Area: ${planets[i].size} </td> </tr>
                <tr> <td colspan="2"> Population: ${planets[i].population} </td> </tr>
                <tr> <td colspan="2"> Development: ${planets[i].development} </td> </tr>
                <tr class="planetRow refuelBtn"> <td colspan="2"> Refuel </td> </tr>
                <tr class="planetRow repairBtn"> <td colspan="2"> Repair </td> </tr>
                <tr class="planetRow hireCrewBtn"> <td colspan="2"> Hire crew </td> </tr>
                <tr class="planetRow"> <td> <a class="showStatBtn" href="">Show stat</a> </td> <td> <a class="goToBtn" href="">Go to</a> </td> </tr>
            </tbody>
        </table>`);
    }

    // Attach click events
    $(".refuelBtn").on("click", function(event)
    {
        let planetID = parseInt($(this).parents(".planet").attr("id"));
        try{
            planets[planetID].refuel(selectedShip);
            updateSelectedShip(selectedShip);
        }
        catch(e)
        {
            console.log(e.message);
            showDialog(e.message);
        }
    });

    $(".repairBtn").on("click", function(event)
    {
        let planetID = parseInt($(this).parents(".planet").attr("id"));
        try{
            planets[planetID].repair(selectedShip);
            updateSelectedShip(selectedShip);
        }
        catch(e)
        {
            console.log(e.message);
            showDialog(e.message);
        }
    });

    $(".hireCrewBtn").on("click", function(event)
    {
        let planetID = parseInt($(this).parents(".planet").attr("id"));
        try{
            planets[planetID].hireCrewMember(selectedShip);
            updateSelectedShip(selectedShip);
        }
        catch(e)
        {
            console.log(e.message);
            showDialog(e.message);
        }
    });
    
    $(".showStatBtn").on("click", function(event)
    {
        event.preventDefault();
    });

    $(".goToBtn").on("click", function(event)
    {
        event.preventDefault();
        let planetID = parseInt($(this).parents(".planet").attr("id"));
        selectedShip.start(planets[planetID])
                .catch( error => {

                    if(error.message.indexOf("Game Over") > -1)
                        displayShips(copyArray(ships));

                    console.log(error.message);
                    showDialog(error.message);
                } );
});
}

function showDialog(textString)
{
    let display = $("#display");
    if(display.find("#block").length === 0)
        display.append(`<div id="block"> <div id="dialog"></div> </div>`);
    else
    {
        display.find("#block").remove();
        display.append(`<div id="block"> <div id="dialog"></div> </div>`);
    }

    let block = $("#block");
    block.css("width", $(document).width() + "px");
    block.css("height", $(document).height() + "px");

    let dialog = $("#dialog");
    dialog.css("top", parseInt($(window).innerHeight()/5) + "px");
    dialog.css("left", parseInt($(window).innerWidth()/2.5) + "px")

    dialog.append(`<div id="text"> </div> <div id="button"> <button id="okBtn">OK</button> </div>`);

    dialog.find("#text").html(`<span>${textString}</span>`);

    dialog.find("#button").on("click", function()
    {
        closeDialog();
    });
}

function closeDialog()
{
    let display = $("#display");
    let block = display.find("#block");
    if(block.length > 0)
        block.remove();
}