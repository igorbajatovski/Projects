class Ship {

    constructor(name, crew, fuel, hullStrength, speed, image)
    {   //"StarFighter", 3, 380, 500, 0.5, "img/StarFighter.png"
        this.name = name;
        this.crew = crew;
        this.fuel = fuel;
        this.maxFuel = fuel;
        this.hullStrength = hullStrength;
        this.maxHullStrength = this.hullStrength;
        this.speed = speed;
        this.credits = 500;
        this.image = image;

        this._isWorking = false;
        this._isDamaged = false;
        this._isDestroyed = false;
        this._dockedPlanet = null;

        this.dockEventsHandlers = [];
        this.spaceEventsHandlers = [];
    }

    _isDocked(planet)
    {
        ////////////// Check if ship is docked at this planet //////////////////
        if(this._dockedPlanet === null)
            return -1;

        let position = -1;
        for(let i  = 0; i < planet.shipsDocked.length; ++i)
        {
            if(this === planet.shipsDocked[i])
                position = i;
        }
        return position;
        /////////////////////////////////////////////////////////////////////////
    }

    set isWorking(value) { this._isWorking = value; }
    get isWorking() { return this._isWorking; }

    set isDamaged(value) { this._isDamaged = value; }
    get isDamaged() { return this._isDamaged; }

    set isDestroyed(value) { this._isDestroyed = value; }
    get isDestroyed() { return this._isDestroyed; }

    set dockedPlanet(value) { this._dockedPlanet = value; }
    get dockedPlanet() { return this._dockedPlanet; }

    async start(planet)
    {
        if(this.isWorking)
            throw new Error("Ship is already travaling to a planet"); 
        
        if(! (planet instanceof Planet) )
            throw new Error("This is not a planet"); 
        
        if(planet === this._dockedPlanet)
            throw new Error("You can't go to that planet. You are already docked on it.");

        if(this.isDamaged)
            throw new Error("Ship is damaged.");

        if(this.isDestroyed)
            throw new Error("Ship is distroyed.");

        if(this.crew === 0)
            throw new Error("Ship has no crew.");

        if( (planet.distance * 20) > this.fuel )
            throw new Error("Ship does not have enough fuel to reach the planet.");
        
        let i = this._isDocked(this._dockedPlanet);
        if(i > -1)
        {
            let a = this._dockedPlanet.shipsDocked.slice(0, i);
            a.push(...this._dockedPlanet.shipsDocked.slice(i+1));
            this._dockedPlanet.shipsDocked = a;
        }

        this.fuel -= (planet.distance * 20);

        this.isWorking = true;

        // Time to travel
        let arriveHandle = setTimeout(() => {
            console.log(`Ship ${this.name} has reached the planet ${planet.name}`);
            this.dock(planet);
        }, planet.distance * 1000/this.speed);

        let space_events = SpaceEvent.generateEvents(planet.distance * 1000/this.speed, events);
        
        for (let space_event of space_events) 
        {
            let result = await space_event.startEvent(this);
            if( !(result instanceof Ship) )
            {
                clearTimeout(arriveHandle);
                if(result === 1)
                    throw new Error("Game Over. Ship has no fuel.");
                if(result === 2)
                    throw new Error("Game Over. Ship has no hull strength.");
                if(result === 3)
                    throw new Error("Game Over. Ship has no crew.");
            }
            
            for (const callback of this.spaceEventsHandlers) {
                callback(space_event, this);
            }
        }
    }

    dock(planet)
    {
        setTimeout(() => {
            planet.shipsDocked.push(this);
            this.isWorking = false;
            this.dockedPlanet = planet;
            console.log(`Ship ${this.name} has docked on planet ${planet.name}`);

            if(this.dockEventsHandlers.length > 0)
            {
                for (let callback of this.dockEventsHandlers) {
                    callback(this);
                }
            }

        }, 2000);
    }

    stats(){
        console.log("------- SHIP STATS -------");
        console.log(`CREW: ${this.crew}`);
        console.log(`FUEL: ${this.fuel}/${this.fuelMax}`);
        console.log(`HULL: ${this.hull}/${this.hullMax}`);
        console.log(`CREDITS: ${this.credits}`);
    }

    addDockEvent(dockEventHandler)
    {
        this.dockEventsHandlers.push(dockEventHandler);
    }

    addSpaceEvent(spaceEventHandler)
    {
        this.spaceEventsHandlers.push(spaceEventHandler);
    }

}