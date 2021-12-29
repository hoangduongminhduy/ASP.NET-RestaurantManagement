$(document).ready(function(){
    CommonJS.LanguageCode = "VN";
})

/**
 * This class includes: 
 * Builder: table, obj
 * Formater: cell; gender, number, date, money
 * Validator: checkRequire, checkFormat
 * DataProcessor: get, post
 * ComponentPresenter: show/hide: dialog, toastMsg, loading
 */
class CommonJS{
    static LanguageCode=null;  

    
    static Builder = {
        table(table, data){
            // Xoa du lieu cu trong tbody di    
            $(`${table} tbody`).empty();
            
            // Lay ra cac cot cua bang:
            let cols = $(`${table} th`);
    
            // Duyet tung phan tu trong du lieu hien co (data)
            for(var obj of data){
                let strHTML = $(`<tr></tr>`);
                for(var col of cols){
                    let fieldName = col.getAttribute('fieldName');
                    let formatType = col.getAttribute('formatType');
                    let value = obj[fieldName];
                    let td = CommonJS.Formater.cell(value, formatType);
                    strHTML.append(td);
                }
    
                // Hoan tat: ghep strHTML
                $(`${table} tbody`).append(strHTML);
            }
        },

        customer(dialog){
            let customer={};
            let inputs = $(`${dialog} input`);
            for(var input of inputs){
                customer[$(input).attr('fieldName')] = $(input).val();
            }
            console.log(customer);
            return customer;
        }
    }

    
    static Formater = {
        // Formater.cell call other function of Formater below it
        cell(value, formatType){
            if(!value) return `<td></td>`;
            if(CommonJS.LanguageCode == null) CommonJS.LanguageCode = "VN";
            switch(formatType){
                case 'gender':
                    value = CommonJS.Formater.gender(value);
                    return `<td class="align-left">${value}</td>`;
                case 'number':
                    value = CommonJS.Formater.number(value);
                    return `<td class="align-right">${value}</td>`;
                case 'ddmmyyyy':
                    value = CommonJS.Formater.date(value);
                    return  `<td class="align-center">${value}</td>`;      
                case 'money':
                    value = CommonJS.Formater.money(value);
                    return  `<td class="align-right">${value}</td>`;      
                
                default: 
                    return `<td class="align-left">${value}</td>`
            }
        },

        gender(value){
            if(value==0){
                return Resource[CommonJS.LanguageCode].Gender.Male;
            } else if(value==1){
                return Resource[CommonJS.LanguageCode].Gender.Female;
            } else {
                return Resource[CommonJS.LanguageCode].Gender.Other;
            }
        },

        number(value){
            //delete all chars that are not number
        },

        date(value){
            value = new Date(value);
            let birthString='';
            let date = value.getDate();
            if (date) {
                let month = value.getMonth() + 1;
                month = (month < 10) ? `0${month}` : month;
                let year = value.getYear() + 1900;
                birthString = `${date}/${month}/${year}`;
            } 
            return birthString;
        },
    
        money(value){
            if(value){
                value = value.toLocaleString('vi-VI', { style: 'currency', currency: 'VND' });
                return value.substr(0, value.length-2);
            } else{
                return '';
            }
        }
    }

 
    static Validator = {
        checkRequire(dialog){
            const requiredInput = $(`${dialog} input[required]`);
            for(var input of requiredInput){
                var value = $(input).val();
                if (value == "" || !value) {
                    $(input).addClass('invalid-input');
                    $(input).attr('title','Thông tin này không được phép để trống'); //TODO: Đoạn này phải dùng toast
                } else {
                    $(input).removeClass('invalid-input');
                    $(input).removeAttr('title');
                }
            } 
            var firstInvalidInput =  requiredInput.filter('.invalid-input')[0];
            if(firstInvalidInput) {
                $(firstInvalidInput).focus();
                return false;
            }
            return true;
        },

        checkFormat(dialog){
            // Validate email, date, money FORMAT:
            var emailInput = $(`${dialog} input[fieldName=Email]`);
            if(emailInput.val()){

            }
            return true;
        }
    }
  

    static DataProcessor = {
        post(obj){
            console.log(JSON.stringify(obj));
            $.ajax({
                url:"http://cukcuk.manhnv.net/api/v1/Customerss",
                method:"POST",
                data: JSON.stringify(obj),
                dataType: 'json',
                contentType: 'application/json',
                async:false
            }).done(function(res){
                alert("Thêm mới thành công!");
            }).fail(function (res) {  
                console.log(res);
            })
        },

        get(){

        }
    }

    static ComponentPresenter = {
        showToastMsg(msg){
            // Define HTML for toast message
            let toastHTML = $(`
                <div class="m-toast-msg">
                <div class="toast-icon"></div>
                <div class="toast-text">thêm mới thành công</div>
                </div>
            `)
            $('body').append(toastHTML);
            setTimeout(() => {
                
            }, timeout);
        },
        
    }
}