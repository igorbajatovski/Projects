$( () => {

// let parsed = parseEquation("2+3*8+2/8-10+20/2*9"); // = 106.25
// console.log(parsed);
// let result = calculate(parsed);
// console.log(result);

// parsed = parseEquation("102+10-20*5/3+20-10-50-107+35-2*3*5/3+100/5*15*11*6/2"); // = 9856.66666666666
// console.log(parsed);
// result = calculate(parsed);
// console.log(result);

console.log("102.25+10.32-20.45*5/3+20-10-50.505-107.2487+35-2*3*5.147/3+100/5*15*11.0012*6/2");
// parsed = parseEquation("102.25+10.32-20.45*5/3+20-10-50.505-107.2487+35-2*3*5.147/3+100/5*15*11.0012*6/2"); // = 9856.5189666666666666666666666667
// console.log(parsed);
// result = calculate(parsed);
// console.log(result);

console.log("-102.25+-10.32-20.45*5/3+20-10-50.505-107.2487+35-2*3*5.147/3+100/5*15*11.0012*6/2");
// parsed = parseEquation("-102.25+-10.32-20.45*5/3+20-10-50.505-107.2487+35-2*3*5.147/3+100/5*15*11.0012*6/2"); // 9631.3789666666666666666666666667
// console.log(parsed);
// result = calculate(parsed);
// console.log(result);

console.log("-102.25+-10.32-20.45*-5/3+20--10-+50.505-107.2487+35-2*+3*5.147/3+100/5*15*-11.0012*6/+2");
// parsed = parseEquation("-102.25+-10.32-20.45*-5/3+20--10-+50.505-107.2487+35-2*+3*5.147/3+100/5*15*-11.0012*6/+2"); // -10082.614366666667
// console.log(parsed);
// result = calculate(parsed);
// console.log(result);

console.log("-102.25-10.32-20.45*(-5/3)+20+10-50.505-107.2487+35-2*3*5.147/3+100/5*15*(-11.0012)*6/2");
// parsed = parseEquation("-102.25-10.32-20.45*-5/3+20+10-50.505-107.2487+35-2*3*5.147/3+100/5*15*-11.0012*6/2"); // -10082.614366666667
// console.log(parsed);
// result = calculate(parsed);
// console.log(result);

// let parsed = parseEquation("5+6*5/0"); // = Infinity
// console.log(parsed);
// let result = calculate(parsed);
// console.log(result);

let parsed = parseEquation("500.325"); //
console.log(parsed);
let result = calculate(parsed);
console.log(result);

let caclulator = {

    errorMessages: ["Invalid input", "Can not divide by zero"],
    error: false,

    result: "",
    inputNumber: "0",
    selectedValue: "",

    equationDisplay: [],
    equationInput: [],

    setInput: function(value)
    {
        this.selectedValue = value;
    },

    getInput: function()
    {
        return this.selectedValue;
    },

    updateEquationDisplay: function(deleteLastEntry = false)
    {
        if(this.inputNumber !== "")
        {    
            if(!deleteLastEntry)
            {
                if( !(this.equationInput.length === 0 && this.selectedValue === "=") )
                {
                    let operators = ["+", "-", "*", "/"];
                    if(operators.includes(this.selectedValue))
                    {
                        // if(this.equationDisplay.length > 0)
                        // {
                        //     let lastElem = this.equationDisplay[this.equationDisplay.length - 1];
                        //     if(!lastElem.includes("recip") && !lastElem.includes("sqrt"))
                        //         this.equationDisplay.push(this.inputNumber);
                        // }
                        // else
                        //     this.equationDisplay.push(this.inputNumber);
                        if(this.equationInput.length - this.equationDisplay.length === 1)
                            this.equationDisplay.push(this.selectedValue);
                        else
                        {
                            this.equationDisplay.push(this.inputNumber);
                            this.equationDisplay.push(this.selectedValue);
                        }
                    }
                    else if(this.selectedValue === "=")
                    {
                        this.equationDisplay.push(this.inputNumber);
                    }
                    else if(this.selectedValue === "recip")
                    {   
                        if(this.equationDisplay.length > 0)
                        {
                            let lastElem = this.equationDisplay[this.equationDisplay.length - 1];
                            if(lastElem.includes("recip") || lastElem.includes("sqrt"))
                                lastElem = `recip(${lastElem})`;
                            else
                                this.equationDisplay.push(lastElem = `recip(${this.inputNumber})`);
                            this.equationDisplay[this.equationDisplay.length - 1] = lastElem;
                        }
                        else
                            this.equationDisplay.push(`recip(${this.inputNumber})`);
                        }
                    else if(this.selectedValue === "sqrt")
                    {
                        if(this.equationDisplay.length > 0)
                        {
                            let lastElem = this.equationDisplay[this.equationDisplay.length - 1];
                            if(lastElem.includes("recip") || lastElem.includes("sqrt"))
                                lastElem = `sqrt(${lastElem})`;
                            else
                                this.equationDisplay.push(lastElem = `sqrt(${this.inputNumber})`);
                            this.equationDisplay[this.equationDisplay.length - 1] = lastElem;
                        }
                        else
                            this.equationDisplay.push(`sqrt(${this.inputNumber})`);
                    }
                    else if(this.selectedValue === "%")
                    {
                        this.updateEquationDisplay(true);
                        // let lastElem = this.equationDisplay[this.equationDisplay.length - 1];
                        // if(operators.includes(lastElem))
                        // {
                        this.equationDisplay.push(this.getNumber());
                        // }
                        // else
                        // {
                        //     this.equationDisplay.pop();
                        //     this.equationDisplay.push(this.getNumber());
                        // }
                    }
                }
            }
            else
            {
                if(this.equationDisplay.length - this.equationInput.length === 1)
                {
                    this.equationDisplay.pop();
                }
            }
        }
    },

    getEquationDisplay: function()
    {
        return this.equationDisplay.join(" ");
    },

    updateEquation: function()
    {
        if(this.inputNumber !== "")
        {
            if( !(this.equationInput.length === 0 && this.selectedValue === "=") )
            {
                this.equationInput.push(this.inputNumber);
                this.equationInput.push(this.selectedValue);
            }
        }
    },

    getEquation: function()
    {
        let equation = "";
        for (let i = 0; i < this.equationInput.length - 1; ++i) {
            equation += this.equationInput[i];
        }
        return equation;
    },

    hasEquation: function()
    {
        if(this.equationInput.length === 0)
            return false;
        return true;
    },

    calculateEquation: function()
    {
        this.updateEquation();
        this.updateEquationDisplay();
        
        this.error = false;
        this.result = "";

        if(this.equationInput.length > 0)
        {
            let parsedEquation = parseEquation(this.getEquation());
            let result = calculate(parsedEquation);
            if(result === Number.POSITIVE_INFINITY || result === Number.NEGATIVE_INFINITY)
            {
                this.result = this.errorMessages[1];
                this.error = true;
                this.inputNumber = "";
            }
            else
            {
                this.result = this.convertNumInExpNotationToFixedNotation(result);
                this.inputNumber = "";
            }

            if(this.equationInput[this.equationInput.length - 1] === "=")
            {
                this.inputNumber = "";
                this.equationInput = [];
                this.equationDisplay = [];
            }
        }
        else
        {
            if(this.selectedValue != "=")
                this.inputNumber = "";
        }
    },

    calculateSqrt: function()
    {
        if(this.inputNumber !== "")
        {
            let num = Number(this.inputNumber);
            if(num >= 0)
            {
                this.updateEquationDisplay();
                let sqrt = Math.sqrt(num);
                this.inputNumber = this.convertNumInExpNotationToFixedNotation(sqrt);
                this.result = this.convertNumInExpNotationToFixedNotation(sqrt);
            }
            else
            {   
                this.updateEquationDisplay();
                this.result = this.errorMessages[0];
                this.error = true;
                this.inputNumber = "";                    
            }
        }
    },

    calculateReciprocitate: function()
    {
        if(this.inputNumber !== "")
        {
            let num = Number(this.inputNumber);
            if(num != 0)
            {
                this.updateEquationDisplay();
                let recip = 1/num;
                this.inputNumber = this.convertNumInExpNotationToFixedNotation(recip);
                this.result = this.convertNumInExpNotationToFixedNotation(recip);
            }
            else
            {
                this.updateEquationDisplay();
                this.result = this.errorMessages[1];
                this.error = true;
                this.inputNumber = "";
            }
        }
    },

    calculatePercentage: function()
    {
        if(this.inputNumber !== "")
        {
            let num = Number(this.inputNumber);
            let percent = 0;
            if(this.getResult() !== "")
                percent = this.getResult() * num/100;
            else
                percent = 0;
            
            if(percent !== 0)
                this.inputNumber = this.convertNumInExpNotationToFixedNotation(percent);
            else
                this.inputNumber = "0";
            
            this.updateEquationDisplay();
        }
    },

    isNumberInExpNotation: function(number)
    {
        let sNum = number.toString();
        let exp = sNum.toLowerCase().indexOf("e");
        if(exp > -1)
            return true;
        return false;
    },

    convertNumInExpNotationToFixedNotation: function(number)
    {
        if(this.isNumberInExpNotation(number))
        {   
            let sNum = number.toString();
            let expIndex = sNum.toLowerCase().indexOf("e");
            let exp = Number(sNum.substring(expIndex+2));
            return number.toFixed(exp);
        }

        return number.toString();
    },

    isError: function()
    {
        return this.error;
    },

    getResult: function()
    {
        return this.result;
    },

    setNumber: function(digit)
    {
        let numbers = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "."];
        if(numbers.includes(digit))
        {
            if(this.inputNumber === "")
                this.inputNumber = "0";
        
            if(digit !== "0" || this.inputNumber !== "0")
            {
                if(digit === "." && this.inputNumber === "0")
                    this.inputNumber += digit;
                else if(this.inputNumber === "0")
                    this.inputNumber = digit;
                else if(digit !== "." || !this.inputNumber.includes("."))
                    this.inputNumber += digit;
            }
        }
        else
        {
            if(!isNaN(digit))
                this.inputNumber = digit;
        }
    },

    getNumber: function()
    {
        return this.inputNumber;
    },

    deleteLastDigit: function()
    {   
        if(this.inputNumber !== "" && this.inputNumber !== "0")
        {
            if(this.getResult() !== "" && !this.hasEquation())
                this.result = "";
            
            this.inputNumber = this.inputNumber.substring(0, this.inputNumber.length-1);
            if(this.inputNumber === "")
                this.inputNumber = "0";
            return true;
        }
        return false;
    },

    negateNumber: function()
    {
        if(this.inputNumber !== "" && this.inputNumber !== "0")
        {
            if(!this.inputNumber.startsWith("-"))
                this.inputNumber = "-" + this.inputNumber;
            else
                this.inputNumber = this.inputNumber.substring(1);
            
            return true;
        }
        return false;
    },

    clearEntryAndResult: function()
    {
        // Clear the calc state
        this.result = "";
        this.error = false;
        this.inputNumber = "0";
        this.equationDisplay = [];
        this.equationInput = [];
    },

    clearEntry: function()
    {
        if(this.inputNumber !== "")
        {
            this.updateEquationDisplay(true);
            this.inputNumber = "0";
            return true;
        }
        return false;
    }
}

function clearInputAndDisplay(calculatorInput, calculatorDisplay)
{
    // Clear the calc fields
    calculatorInput.val("0");
    calculatorDisplay.val("");
}

$("#calculator button").on("click", function(event, data = null)
{
    event.target.setAttribute("disabled", "disabled");
    let calculatorInput = $("#calculatorInput");
    let calculatorDisplay = $("#calculatorDisplay");
    caclulator.setInput(event.target.value);

    if(data !== null)
        event.target.setAttribute("style", "background-color: rgb(200, 200, 200);");
    
    if(!caclulator.isError())
    {
        // Entry of digits
        let numbers = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "."];
        if(numbers.includes(caclulator.getInput()))
        {
            if(caclulator.getResult() !== "" && !caclulator.hasEquation())
            {
                caclulator.clearEntryAndResult();
                clearInputAndDisplay(calculatorInput, calculatorDisplay);
            }

            caclulator.setNumber(caclulator.getInput());
            calculatorInput.val(caclulator.getNumber());
            calculatorInput.removeAttr("style");
        }

        // Delete the last digit of entered number
        if(caclulator.getInput() === "del")
        {
            if(caclulator.deleteLastDigit())
                calculatorInput.val(caclulator.getNumber());
        }

        // Change the aritmetic sign of the number
        if(caclulator.getInput() === "neg")
        {
            if(caclulator.negateNumber())
                calculatorInput.val(caclulator.getNumber());
        }

        // Calculate square root
        if(caclulator.getInput() === "sqrt")
        {
            caclulator.calculateSqrt();
            if(!caclulator.isError())
            {
                calculatorDisplay.val(caclulator.getEquationDisplay());
                calculatorInput.val(caclulator.getResult());
                calculatorInput.attr("style", "color:rgb(200,200,200);");
            }
            else
            {
                calculatorDisplay.val(caclulator.getEquationDisplay());
                calculatorInput.val(caclulator.getResult());
            }
        }

        // Calculate reciprocitate of a number
        if(caclulator.getInput() === "recip")
        {
            caclulator.calculateReciprocitate();
            if(!caclulator.isError())
            {
                calculatorDisplay.val(caclulator.getEquationDisplay());
                calculatorInput.val(caclulator.getResult());
                calculatorInput.attr("style", "color:rgb(200,200,200);");
            }
            else
            {
                calculatorDisplay.val(caclulator.getEquationDisplay());
                calculatorInput.val(caclulator.getResult()); 
            }
        }

        // Calculate percentage of a number
        if(caclulator.getInput() === "%")
        {
            caclulator.calculatePercentage();
            calculatorDisplay.val(caclulator.getEquationDisplay());
            calculatorInput.val(caclulator.getNumber());
            calculatorInput.attr("style", "color:rgb(200,200,200);");
        }

        // Caclulate equation
        let operators = ["+", "-", "*", "/", "="];
        if(operators.includes(caclulator.getInput()))
        {   
            // Calculate the result till the last operation
            caclulator.calculateEquation();
            if(!caclulator.isError())
            {
                calculatorDisplay.val(caclulator.getEquationDisplay());

                if(caclulator.getResult() !== "")
                {
                    calculatorInput.val(caclulator.getResult());
                    calculatorInput.attr("style", "color:rgb(200,200,200);");
                }

                if(caclulator.getInput() === "=")
                    if(caclulator.getResult() !== "" && !caclulator.hasEquation())
                    {
                        caclulator.setNumber(caclulator.getResult());
                        calculatorInput.removeAttr("style");
                    }
            }
            else
            {
                calculatorInput.val(caclulator.getResult());
                calculatorInput.removeAttr("style");
            }
        }
        
    }// end of if(!errorMessages.includes(result))

    // Clear the entry
    if(caclulator.getInput() === "ce")
    {
        if(!caclulator.isError())
        {
            if(caclulator.clearEntry())
            {
                calculatorInput.val(caclulator.getNumber());
                calculatorDisplay.val(caclulator.getEquationDisplay());
                calculatorInput.removeAttr("style");
            }
        }
        else
        {
            caclulator.clearEntryAndResult();
            clearInputAndDisplay(calculatorInput, calculatorDisplay);
            calculatorInput.removeAttr("style");
        }
    }

    // Clear the entry and result
    if(caclulator.getInput() === "c")
    {
        caclulator.clearEntryAndResult();
        clearInputAndDisplay(calculatorInput, calculatorDisplay);
        calculatorInput.removeAttr("style");
    }

    setTimeout( () => {event.target.removeAttribute("disabled")}, 300);
    if(data !== null)
        setTimeout(() => {event.target.removeAttribute("style");}, 300);
})


$(document).keyup(function(event)
{
    // console.log("event.which:" + event.which);
    // console.log("event.char:" + event.char);
    // console.log("event.charCode:" + event.charCode);
    // console.log("event.key:" + event.key);
    // console.log("event.keyCode:" + event.keyCode);

    let key = event.which;
    switch(key)
    {
        case 96: {
            $("#zeroBtn").trigger("click", {});
            break;
        }

        case 97:{
            $("#oneBtn").trigger("click", {});
            break;
        }

        case 98:{
            $("#twoBtn").trigger("click", {});
            break;
        }

        case 99:{
            $("#threeBtn").trigger("click", {});
            break;
        }

        case 100:{
            $("#fourBtn").trigger("click", {});
            break;
        }

        case 101:{
            $("#fiveBtn").trigger("click", {});
            break;
        }

        case 102:{
            $("#sixBtn").trigger("click", {});
            break;
        }

        case 103:{
            $("#sevenBtn").trigger("click", {});
            break;
        }

        case 104:{
            $("#eightBtn").trigger("click", {});
            break;
        }

        case 105:{
            $("#nineBtn").trigger("click", {});
            break;
        }

        // Dot
        case 110:{
            $("#dotBtn").trigger("click", {});
            break;
        }

        // Plus
        case 107:{
            $("#plusBtn").trigger("click", {});
            break;
        }

        // Minus
        case 109:{
            $("#minusBtn").trigger("click", {});
            break;
        }

        // Multiply
        case 106:{
            $("#multiplyBtn").trigger("click", {});
            break;
        }

        // Devide
        case 111:{
            $("#devideBtn").trigger("click", {});
            break;
        }

        // Enter
        case 13:{
            $("#equalBtn").trigger("click", {});
            break;
        }

        // Backspace
        case 8:{
            $("#deleteBtn").trigger("click", {});
            break;
        }

        // Escape
        case 27:{
            $("#clearEntryBtn").trigger("click", {});
            break;
        }

        // Delete
        case 46:{
            $("#clearBtn").trigger("click", {});
            break;
        }
    }

})

})