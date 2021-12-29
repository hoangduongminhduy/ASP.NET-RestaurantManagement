<template>
<div id="root">
  <TheNavbar/>
  <div class="content">
    <TheHeader/>
    <TheContent/>
  </div>
</div>
</template>

<script>
import TheNavbar from './layouts/TheNavbar.vue'
import TheHeader from './layouts/TheHeader.vue'
import TheContent from './layouts/TheContent.vue'
export default {
  name: 'App',
  components: {
    TheNavbar, TheHeader, TheContent
  },
  watch: {
    $route: {
      immediate: true,
      handler(to) {
        document.title = to.meta.title || 'Cukcuk';
      }
    },
  }

}
</script>


<style lang="css" scoped>
@import url("./css/common/main.css");
#root{
  margin:0;
  display: flex;
  flex-direction: row;
  font-family: GoogleSans;
  font-size:13px;
}
.content {
  width: calc(100vw - 226px); /*TODO: Căn chỉnh để table scroll theo chiều ngang*/
  flex:1;
  display: flex;
  flex-direction: column;
}   
</style>