<template>
  <div class="grid-item">
    <div data-toggle="modal" :data-target="'#keep-'+keepProp.id" class="keepComponent card text-light h-100 w-100 " :style="{ backgroundImage: `url('${keepProp.img}')`, backgroundSize: 'cover' , backgroundRepeat: 'no-repeat'}">
      <h3>
        {{ keepProp.name }}
        <!-- TODO add pointer css  -->
        <div class="text-dark" @click.stop="gotoprofile">
          <img class="m-3 justify-content-right pic" :src="keepProp.creator.picture" alt="">
        </div>
      </h3>
    </div>

    <!-- Modal -->
    <div class="modal fade"
         :id="'keep-'+keepProp.id"
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
                <router-link class="text-dark" :to="{name: 'ProfilePage', params: {id : keepProp.id}}">
                  <img class="m-3 justify-content-right pic" :src="keepProp.creator.picture" alt="">
                </router-link>
                <i class="fa fa-trash text-danger" data-dismiss="modal" @click="deleteKeep" v-if="keepProp.creatorId == state.account.id" aria-hidden="true"></i>
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <div class="dropdown">
              <button class="btn btn-secondary dropdown-toggle"
                      type="button"
                      id="dropdownMenuButton"
                      data-toggle="dropdown"
                      aria-haspopup="true"
                      aria-expanded="false"
              >
                Dropdown button
              </button>
              <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                <a class="dropdown-item" href="#">Action</a>
                <a class="dropdown-item" href="#">Another action</a>
                <a class="dropdown-item" href="#">Something else here</a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState'
import { useRouter } from 'vue-router'
export default {
  name: 'KeepComponent',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const router = useRouter()
    const state = reactive({
      account: computed(() => AppState.account)
    })
    return {

      state,
      deleteKeep() {
        confirm('Are you sure?')
        keepsService.deleteKeep(props.keepProp.id)
      },
      gotoprofile() {
        router.push({ name: 'ProfilePage', params: { id: props.keepProp.creatorId } })
      }
    }
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
  background-image: url("keepProp.img");
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
