const Resource = {
    apiCustomer: 'http://cukcuk.manhnv.net/api/v1/Customerss/',
    apiEmployee: 'http://cukcuk.manhnv.net/api/v1/Employeess/',

    FormMode: {
        Hidden: 0,
        Add: 1,
        Edit: 2,
    },
    
    VN:{
        Gender:{
            0: 'Nữ',
            1: 'Nam',
            2: 'Khác'
        },
        DeleteComfirm: function(element){
            return `Bạn có chắc muốn xóa ${element} không?`;
        } 
    },
    EN:{
        Gender:{
            Male: 'Male',
            Female: 'Female',
            Other: 'Other'
        },
        DeleteComfirm: function(element){
            return `Are you sure to delete ${element}?`;
        } 
    }
}
export default Resource;