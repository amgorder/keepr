<template>
  <div class="grid">
    <div class="keepComponent card grid-item grid-item--width2">
      <img class="card" :src="keepProp.img" alt="">
      <h3>{{ keepProp.name }}<img class="m-3 justify-content-right pic" :src="keepProp.creator.picture" alt=""></h3>
      <p>{{ keepProp.description }}</p>
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
export default {
  name: 'KeepComponent',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup() {
    const state = reactive({
    })
    return { state }
  }
}
</script>

<style scoped>
.grid-item { width: 200px; }
.grid-item--width2 { width: 400px; }

.card {
  /* height: 200px;
  width: 100px; */
  padding: 3px;
  margin: 3px;
}
.pic{
  display: inline-block;
  padding: 4px;

  background: linear-gradient(130deg,  hsl(150, 99%, 48%), hsl(275, 99%, 48%));
  object-fit: cover;
  margin: auto;
  border-radius: 50%;
  width: 50px;
  height:50px;
  box-shadow: 6px,6px,12px,16px black;
}
</style>
