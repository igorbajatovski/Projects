$(
    () =>
    {
        // other.js
        let script = document.createElement("script");
        let attr = document.createAttribute("src");
        attr.value = "other.js";
        script.setAttributeNode(attr);
        attr = document.createAttribute("type");
        attr.value = "text/javascript";
        script.setAttributeNode(attr);
        let body = document.getElementsByTagName("body")[0];
        body.appendChild(script);
        
        // display.js
        script = document.createElement("script");
        attr = document.createAttribute("src");
        attr.value = "display.js";
        script.setAttributeNode(attr);
        attr = document.createAttribute("type");
        attr.value = "text/javascript";
        script.setAttributeNode(attr);
        body = document.getElementsByTagName("body")[0];
        body.appendChild(script);

        // events.js
        script = document.createElement("script");
        attr = document.createAttribute("src");
        attr.value = "events.js";
        script.setAttributeNode(attr);
        attr = document.createAttribute("type");
        attr.value = "text/javascript";
        script.setAttributeNode(attr);
        body.appendChild(script);

        // people.js
        script = document.createElement("script");
        attr = document.createAttribute("src");
        attr.value = "people.js";
        script.setAttributeNode(attr);
        attr = document.createAttribute("type");
        attr.value = "text/javascript";
        script.setAttributeNode(attr);
        body.appendChild(script);

        // planets.js
        script = document.createElement("script");
        attr = document.createAttribute("src");
        attr.value = "planets.js";
        script.setAttributeNode(attr);
        attr = document.createAttribute("type");
        attr.value = "text/javascript";
        script.setAttributeNode(attr);
        body.appendChild(script);
    }
)