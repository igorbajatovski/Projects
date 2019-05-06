class Planet {

    constructor(name, size, population, distance, development, image)
    {   //"Rubicon9", 300000, 2000000, 4, 2, "img/Rubicon9.png"
        this.name = name;
        this.size = size;
        this.population = population;
        this.distance = distance;
        this.development = development;
        this.image = image;

        this.shipsDocked = [];
    }

    _isDocked(ship)
    {
        ////////////// Check if ship is docked at this planet //////////////////
        let found = false;
        for(let i  = 0; i < this.shipsDocked.length; ++i)
        {
            if(ship === this.shipsDocked[i])
                found = true;
        }
        
        return found;
        /////////////////////////////////////////////////////////////////////////
    }

    getMarketPrice(price)
    {
        return (this.development * price)  / Math.round(this.population / this.size);
    }

    repair(ship)
    {
        if( !(ship instanceof Ship) )
            throw new Error("This not a ship. Can not be repeaired.");
        
        if(!this._isDocked(ship))
            throw new Error(`Ship ${ship.name} is not docked at this planet. Can not be repaired.`);

        if(ship.hullStrength === ship.maxHullStrength)
            throw new Error(`Ship ${ship.name} hull is already at max strength.`);

        if(ship.credits < this.getMarketPrice(price.repair))
            throw new Error(`Ship ${ship.name} can not be repeared. Does not have enough credits.`);

        ship.hullStrength = ship.maxHullStrength;
        ship.credits -= this.getMarketPrice(price.repair);
        ship.isDamaged = false;
        console.log(`Ship ${ship.name} is repaired.`);
    }

    refuel(ship)
    {
        if( !(ship instanceof Ship) )
            throw new Error("This not a ship. Can not be refueled.");

        if(!this._isDocked(ship))
            throw new Error(`Ship ${ship.name} is not docked at this planet. Can not be refueled.`);

        if(ship.fuel === ship.maxFuel)
            throw new Error(`Ship ${ship.name} can not be refueled, already at max fuel.`);

        if(ship.credits < this.getMarketPrice(price.fuel))
            throw new Error(`Ship ${ship.name} can not be refueled. Does not have enough credits.`);

        ship.fuel = ship.maxFuel;
        ship.credits -= this.getMarketPrice(price.fuel);
        console.log(`Ship ${ship.name} is refueled`);
    }

    hireCrewMember(ship)
    {
        if( !(ship instanceof Ship) )
            throw new Error("This not a ship. Can not be refueled.");

        if(!this._isDocked(ship))
            throw new Error(`Ship ${ship.name} is not docked at this planet. Can not hire crew.`);

        if(ship.credits < this.getMarketPrice(price.crew))
            throw new Error(`Ship ${ship.name} can not have another crew member. Does not have enough credits.`);

        ship.crew += 1;
        ship.credits -= this.getMarketPrice(price.crew);
        console.log(`One crew member hired for ship ${ship.name}.`);
    }

}