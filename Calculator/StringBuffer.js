 // #################   String Buffer  ######################## 
 function StringBuffer(value)
 {
     this.value = new String(value);
 }
 
 StringBuffer.prototype.toString = function()
 {
     return this.value.toString()
 }
 
 StringBuffer.prototype.insert = function(position, value)
 {
     if(position > this.value.length)
         return;
 
     if(position < 0)
         return;
     
     let leftSide = this.value.substring(0, position);
     let rightSide = this.value.substring(position);
 
     this.value = leftSide + value + rightSide;
 }
 
 StringBuffer.prototype.getItem = function(index)
 {
     return this.value[index];
 }
 
 StringBuffer.prototype.length = function()
 {
     return this.value.length;
 }
 
 // ############################################################