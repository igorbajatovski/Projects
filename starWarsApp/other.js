function isPlanet(item)
{
    if(item.name  !== undefined && item.diameter !== undefined && item.climate !== undefined &&
        item.terrain !== undefined && item.rotation_period !== undefined && item.population !== undefined)
        return true;
     return false;
}

function isPeople(item)
{
    if(item.name  !== undefined && item.gender !== undefined && item.birth_year !== undefined &&
        item.height !== undefined && item.mass !== undefined)
        return true;
    return false;
}

function parseProperty(property)
{
    if(!isNaN(property))
        return property;
    
    if(property !== "n/a")
    {
        property = property.replace(new RegExp("_", "g"), " ");
        property = property.substring(0,1).toUpperCase() + property.substring(1);
    }
    else
        property = property.toUpperCase();
    return property;
}