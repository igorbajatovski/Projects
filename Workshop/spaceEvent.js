class SpaceEvent {
    //new SpaceEvent("Fuel Leak", "Due to low maintenance of the ship, the fuel tank leaked. The leak was patched, but we lost some fuel.", 
    //                0, -50, 0 ),
    constructor(name, description, crewModifier, fuelModifier, hullmodifier)
    {
        this.name = name;
        this.description = description;
        this.crewModifier = crewModifier;
        this.fuelModifier = fuelModifier;
        this.hullmodifier = hullmodifier;
    }

    startEvent(ship)
    {
        if( !(ship instanceof Ship) )
            throw Error("This is not a ship");

        let _event = new Promise( (resolve, reject) => {
            setTimeout( () => {

                if(ship.fuel + this.fuelModifier > ship.maxFuel)
                    ship.fuel = ship.maxFuel;
                else if(ship.fuel + this.fuelModifier <= 0)
                {
                    ship.fuel = 0;
                    resolve(1);
                    return;
                }
                else
                    ship.fuel += this.fuelModifier;

                if(ship.hullStrength + this.hullmodifier > ship.maxHullStrength)
                    ship.hullStrength = ship.maxHullStrength;
                else if(ship.hullStrength + this.hullmodifier <= 0)
                {
                    ship.hullStrength = 0;
                    resolve(2);
                    return;
                }
                else
                    ship.hullStrength += this.fuelModifier;
                
                ship.hullStrength += this.hullmodifier;

                if(ship.crew + this.crewModifier <= 0)
                {
                    ship.crew = 0;
                    resolve(3);
                    return;
                }
                else
                    ship.crew += this.crewModifier;
                
                resolve(ship);
            }, 4000 );
        } );

        return _event;
    }

    static generateEvents(time, events)
    {
        let generateRandom = (min, max) => { return (Math.random() * (max - min) + min) }
        
        let resultEvents = [];

        let numEvents = 1;
        if(time > 26000)
            numEvents = 4;
        else if(time > 18000)
            numEvents = 3;
        else if(time > 8000)
            numEvents = 2;

        for(let i = 0; i < numEvents; ++i) 
            resultEvents.push(events[parseInt(generateRandom(0, events.length - 1))]);

        return resultEvents;
    }
}