<template>
  <div class="grid-item">
    <div class="vaultComponent card text-light h-100 w-100 " :style="{ backgroundImage: `url('${vaultProp.img}')`, backgroundSize: 'cover' , backgroundRepeat: 'no-repeat'}">
      <h3>
        {{ vaultProp.name }}
        <img class="m-3 justify-content-right pic" :src="vaultProp.creator.picture" alt="">
      </h3>
    </div>
  </div>
</template>

<script>
import { reactive } from 'vue'
export default {
  name: 'VaultComponent',
  props: {
    vaultProp: {
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

<style>
/* .grid-item { width: 100px; } */

/* .card {
  width: 200px;

  padding: 3px;
  margin: 3px;
} */

/* .bg-img{
  background-image: url("vaultProp.img");
} */

.pic{
  display: inline-block;
  padding: 4px;

  background: linear-gradient(130deg,  hsl(150, 99%, 48%), hsl(150, 99%, 48%));
  object-fit: cover;
  margin: auto;
  border-radius: 50%;
  width: 50px;
  height:50px;
  box-shadow: 6px,6px,12px,16px black;
}
</style>
