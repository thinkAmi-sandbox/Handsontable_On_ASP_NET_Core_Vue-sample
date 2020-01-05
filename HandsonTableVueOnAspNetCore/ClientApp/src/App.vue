<template>
  <div id="app">
    <!-- Handsontableの表示へと変更
    <img alt="Vue logo" src="./assets/logo.png">
    <HelloWorld msg="Welcome to Your Vue.js + TypeScript App"/>
    -->
    <div>
      <h3>Hello Handsontable</h3>
      <HelloHandsontable />
    </div>
    
    <hr>
    
    <div>
      <h3>Const Response Handsontable</h3>
      <ConstResponseHandsontable />
    </div>
    
    <hr>
    
    <div>
      <h3>Model Response Handsontable</h3>
      <ModelResponseHandsontable />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import HelloWorld from './components/HelloWorld.vue';
import HelloHandsontable from "@/components/HelloHandsontable.vue";
import ConstResponseHandsontable from "@/components/ConstResponseHandsontable.vue";
import ModelResponseHandsontable from "@/components/ModelResponseHandsontable.vue";

@Component({
  components: {
    ModelResponseHandsontable,
    ConstResponseHandsontable,
    HelloHandsontable,
    HelloWorld,
  },
})
export default class App extends Vue {}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
