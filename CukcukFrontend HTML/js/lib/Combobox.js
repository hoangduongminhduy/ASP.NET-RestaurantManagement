class Combobox{
    static initEvent(){
        // for init combobox
        $('.combobox').ready(function () {  
            var comboboxes = $('.combobox');
            for(var combobox of comboboxes){
                combobox = $(combobox);
                var selectedItem = $($(combobox.children('.combobox-select')[0]).children('.combobox-item-selected')[0]); 
                var comboboxInput = $(combobox.children('.combobox-input')[0]); 
                comboboxInput.val(selectedItem.text()); 
            }
        })

        // event for click combobox-btn
        $('.combobox-btn').click(function(){
            let comboboxBtn = $(this);
            comboboxBtn.toggleClass('combobox-btn-selected');
            let comboboxSelect = comboboxBtn.siblings('.combobox-select');
            comboboxSelect.toggle();
        })
        
        // event for click combobox-itemm
        $('.combobox-item').click(function(){
            // get item clicked
            const selectedItem = $(this);

            // remove selected for all combobox-item
            for(var item of selectedItem.siblings()){
                $(item).removeClass('combobox-item-selected');
            }

            // change clicked combobox-item to selected
            $(selectedItem).addClass('combobox-item-selected');

            // hide combobox-select
            let comboboxSelect = selectedItem.parent();
            comboboxSelect.hide();

            // remove selected for combobox-button
            let comboboxBtn = comboboxSelect.siblings('.combobox-btn');
            $(comboboxBtn).removeClass('combobox-btn-selected');
            
            // change combobox-input value
            let comboboxInput = comboboxSelect.siblings('.combobox-input');
            $(comboboxInput).val($(selectedItem).text());
        })
    }
}