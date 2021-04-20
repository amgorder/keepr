<template>
  <div class="container-fluid">
    <div class="keepComponent text-center col-3 card m-2">
      <img class="card" :src="keepProp.img" alt="">
      <h3>{{ keepProp.name }}</h3>
      <!-- <p>{{ keepProp.creator.picture }}</p> -->
      <img class="card-img-center mt-3 pic d-flex justify-content-center" :src="keepProp.creator.picture" alt="">
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

/* .card {
  height: 20em;
  width: 10em;
} */
.pic{
  display: inline-block;
  padding: 8px;

  background: linear-gradient(130deg, rgb(187, 9, 241), rgb(6, 228, 236));
  object-fit: cover;
  margin: auto;
  border-radius: 50%;
  width: 200px;
  height:200px;
  box-shadow: 6px,6px,12px,16px black;
}
</style>
