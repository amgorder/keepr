<template>
  <div class="grid">
    <div class="keepComponent card grid-item--width2 " :style="{ backgroundImage: `url('${keepProp.img}')`, backgroundSize: 'contain' , backgroundRepeat: 'no-repeat'}">
      <!-- <img class="card" :src="keepProp.img" alt=""> -->
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
    <div class="modal-dialog modal-xl" role="document">
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
          <div class="row">
            <div class="col">
              <img class="card img-fluid" :src="keepProp.img" alt="">
            </div>
            <div class="col">
              <p>{{ keepProp.description }}</p>
              Views: {{ keepProp.views }}
              Share: {{ keepProp.shares }}
              Keeps: {{ keepProp.keeps }}
              <br>
              <img class="m-3 justify-content-right pic" :src="keepProp.creator.picture" alt="">
            </div>
          </div>
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
.grid-item { width: 100px; }
.grid-item--width2 { width: 400px; }

/* .card {
  height: auto;
width: auto;
  padding: 3px;
  margin: 3px;
} */

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
