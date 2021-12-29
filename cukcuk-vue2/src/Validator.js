const Format = [
    function Gender(value){
        return Resource.VN.Gender[value];
    },
    function Number(value){
        return value;
        // return value.replace(/\D/g,'');
    },
    function Date (value) {
        if (value) {
          value = new Date(value);
          let date = value.getDate();
          let month = value.getMonth() + 1;
          let year = value.getFullYear();
          date = date < 10 ? `0${date}` : date;
          month = month < 10 ? `0${month}` : month;
          return `${date}/${month}/${year}`;
        } 
        else return "";
      },
    function Money (value) {
    if (value) {
        value = value.toLocaleString('vi-VI', { style: 'currency', currency: 'VND' });
        return value.substr(0, value.length-2);
    }
    else return "";
    },
]


export const Format;