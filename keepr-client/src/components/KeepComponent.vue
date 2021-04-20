<template>
  <div class="grid">
    <div class="keepComponent card bg-img grid-item grid-item--width2">
      <img class="card" :src="keepProp.img" alt="">
      <h3>{{ keepProp.name }}<img class="m-3 justify-content-right pic" :src="keepProp.creator.picture" alt=""></h3>
      <!-- Button trigger modal -->
      <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
        Keep Info Modal
      </button>
    </div>
  </div>

  <!-- Modal -->
  <div class="modal fade"
       id="exampleModal"
       tabindex="-1"
       role="dialog"
       aria-labelledby="exampleModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            {{ keepProp.name }}
          </h5>
          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <div class="modal-body">
          <img class="card" :src="keepProp.img" alt="">

          <p>{{ keepProp.description }}</p>
          <img class="m-3 justify-content-right pic" :src="keepProp.creator.picture" alt="">
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-dismiss="modal">
            Close
          </button>
        </div>
      </div>
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

/* .bg-img{
  background-image: url("keepProp.img");
} */

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
