<template>
  <div class="grid-item">
    <div data-toggle="modal" :data-target="'#vault-'+vaultProp.id" class="vaultComponent card text-light h-100 w-100 " :style="{ backgroundImage: `url('${vaultProp.img}')`, backgroundSize: 'cover' , backgroundRepeat: 'no-repeat'}">
      <h3>
        {{ vaultProp.name }}
        <img class="m-3 justify-content-right pic" :src="vaultProp.creator.picture" alt="">
      </h3>
    </div>

    <!-- Modal -->
    <div class="modal fade"
         :id="'vault-'+vaultProp.id"
         tabindex="-1"
         role="dialog"
         aria-labelledby="exampleModalLabel"
         aria-hidden="true"
    >
      <div class="modal-dialog modal-xl" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">
              {{ vaultProp.name }}
            </h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <div class="row">
              <div class="col">
                <img class="card img-fluid" :src="vaultProp.img" alt="">
              </div>
              <div class="col">
                <p>{{ vaultProp.description }}</p>

                <br>
                <img class="m-3 justify-content-right pic" :src="vaultProp.creator.picture" alt="">
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
