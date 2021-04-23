<template>
  <div class="masonryholder">
    <keep-component v-for="k in state.keeps" :key="k.id" :keep-prop="k" class="keep-component" />
  </div>
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'

export default {
  name: 'Home',
  setup() {
    const state = reactive({
      keeps: computed(() => AppState.keeps)
    })
    onMounted(() => keepsService.getKeeps())
    return { state }
  }
}
</script>

<style lang="scss">

.keep-component {
  height: 10rem;
  width: 12rem;
  padding: 3px;
  margin: 3px;
  display: inline-block;
 }

// .keep-component:nth-child(2n) {
//   height: 20rem !important;
//   width: 12rem !important;
//  }

// .keep-component:nth-child(3n) {
//   height: 18rem !important;
//   width: 12rem !important;
//  }
// .keep-component:nth-child(4n) {
//   height: 15rem !important;
//   width: 12rem !important;
//  }
//  .masonryholder{
//   column-count: 4;
//   column-gap: 20px;
// }

// @media screen and (max-width: 768px){
// .masonryholder{
//   column-count: 1;
// }
// }
// @media screen and (min-width: 769px){
// .masonryholder{
//   column-count: 2;
// }
// }
// @media screen and (min-width: 1080px){
// .masonryholder{
//   column-count: 3;
// }
// }
// @media screen and (min-width: 1200px){
// .masonryholder{
//   column-count: 4;
// }
// }
</style>
