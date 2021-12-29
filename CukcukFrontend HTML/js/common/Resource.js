Resource = {
    VN:{
        Gender:{
            Male: 'Nam',
            Female: 'Nữ',
            Other: 'Khác'
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