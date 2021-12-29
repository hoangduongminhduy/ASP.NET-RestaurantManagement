<template lang="">
    <div ref="toastMsg" v-show="isShow" class="toast-msg">
        <div class="toast-icon"></div>
        <div class="toast-text">{{toastText}}</div>
        <button @click="onClickCloseBtn"></button>
    </div>
</template>
<script>
export default {
    props: {
        toastText: String,
        isShow: Boolean,
        toastType: String
    },
    watch:{
        toastType: function(){
            var me=this;
            if(me.toastType){
                var className = "toast-msg-" + me.toastType;
                this.$refs.toastMsg.classList.add(className);
            } else {
                this.$refs.toastMsg.classList = this.$refs.toastMsg.classList = ['toast-msg']
            }
        }
    },

    methods:{
        onClickCloseBtn(){
            this.$emit("displayToastMsg", false, null, null);
        }
    }
}
</script>
<style lang="css" scoped>
    .toast-msg{
        display:flex;
        position: absolute !important;
        bottom: 25px !important;
        right: 25px !important;
        z-index: 9999;
        width: 230px !important;
        height: 48px !important;
        line-height:48px;
        border-radius: 4px;
        padding: 0 10px 0 56px;
        box-sizing:border-box;
        border: none;
        background: #fff 20px center no-repeat;
        background-size: 24px 24px;
        box-shadow: 0 3px 6px rgba(0,0,0,0.16);
        font-size:13px;
        /* align-items: center; */
    }
        .toast-text{
            flex:1;
        }
        
        button{
            padding:0;
            width:16px;
            height:16px;
            border:none;
            cursor:pointer;
            align-self:center;
        }

        .toast-msg-fail{
            background-image: url('../assets/icon/toast-fail-icon.png');
        }
            .toast-msg-fail button{
                background: url('../assets/icon/toast-fail-x.png') no-repeat;
                background-size:16px 16px;
            }
        .toast-msg-warn{
            background-image: url('../assets/icon/toast-warn-icon.png');
        }
            .toast-msg-warn button{
                background: url('../assets/icon/toast-warn-x.png') no-repeat;
                background-size:16px 16px;
            }
        .toast-msg-success{
            background-image: url('../assets/icon/toast-success-icon.png');
        }
            .toast-msg-success button{
                background: url('../assets/icon/toast-success-x.png') no-repeat;
                background-size:16px 16px;
            }
        .toast-msg-info{
            background-image: url('../assets/icon/toast-info-icon.png');
        }
            .toast-msg-info button{
                background: url('../assets/icon/toast-info-x.png') no-repeat;
                background-size:16px 16px;
            }

    .toast-icon{
        /* float: left;
        background-image: url('../assets/icon/x.svg');
        width:24px;
        height: 24px;
        background-repeat: no-repeat;
        background-size: contain;
        background-position:center; */
    }
</style>