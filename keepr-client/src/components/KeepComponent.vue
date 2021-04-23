<template>
  <div class="masonryblocks border-wrap round col-md-3">
    <span></span>
    <span></span>
    <span></span>
    <span></span>
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
                <!-- <router-link class="text-dark" @click.stop="gotoprofile"> -->
                <img class="m-3 justify-content-right pic" :src="keepProp.creator.picture" alt="">
                <!-- </router-link> -->
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
                <a class="dropdown-item" href="#" @click="createVaultKeep( keepProp.id, v.id)" v-for="v in state.vaults" :key="v.id">{{ v.name }}</a>
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
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults)
    })
    return {

      state,
      deleteKeep() {
        confirm('Are you sure?')
        keepsService.deleteKeep(props.keepProp.id)
      },
      gotoprofile() {
        router.push({ name: 'ProfilePage', params: { id: props.keepProp.creatorId } })
      },
      createVaultKeep(keepId, vaultId) {
        const newVK = {
          keepId: keepId, vaultId: vaultId
        }
        console.log(newVK)
        keepsService.createVaultKeep(newVK)
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

  background: linear-gradient(130deg, hsl(44, 98%, 50%), hsl(44, 98%, 25%));
  object-fit: cover;
  margin: auto;
  border-radius: 50%;
  width: 25px;
  height:25px;
  box-shadow: 6px,6px,12px,16px black;
}

/* .round{
  border-color: hsl(44, 98%, 25%);
  border-radius: 5px;
} */

.border-wrap{
  text-decoration: none;
  transition: 0.2s;
  overflow: hidden;
}

.border-wrap:hover{
  color: #d4af37;
  background: #d4af37;
  box-shadow: 0 0 10px #d4af37, 0 0 40px #d4af37, 0 0 80px #d4af37;
  transition-delay: 1s;

}
.border-wrap span{
  position: absolute;
  display: block;
}
.border-wrap span:nth-child(1){
  top: 0;
  left: -100%;
  width: 100%;
  height: 2px;
  background: linear-gradient(90deg,transparent,#d4af37);
}
.border-wrap:hover span:nth-child(1){
  left: 100%;
  transition: 1s;
}
.border-wrap span:nth-child(3){
  bottom: 0;
  right: -100%;
  width: 100%;
  height: 2px;
  background: linear-gradient(270deg,transparent,#d4af37);
}
.border-wrap:hover span:nth-child(3){
  right: 100%;
  transition: 1s;
  transition-delay: 0.5s;

}
.border-wrap span:nth-child(2){
  top: -100%;
  right: 0;
  width: 2px;
  height: 100%;
  background: linear-gradient(180deg,transparent,#d4af37);
}
.border-wrap:hover span:nth-child(2){
  top: 100%;
  transition: 1s;
  transition-delay: 0.25s;
}
.border-wrap span:nth-child(4){
  bottom: -100%;
  left: 0;
  width: 2px;
  height: 100%;
  background: linear-gradient(360deg,transparent,#d4af37);
}
.border-wrap:hover span:nth-child(4){
  bottom: 100%;
  transition: 1s;
  transition-delay: 0.75s;
}

.keep-component {
  height: 10rem;
  width: 12rem;
  padding: 3px;
  margin: 3px;
  display: inline-block;
 }
/*
.keep-component:nth-child(2n) {
  height: 20rem !important;
  width: 12rem !important;
 }

.keep-component:nth-child(3n) {
  height: 18rem !important;
  width: 12rem !important;
 }
.keep-component:nth-child(4n) {
  height: 15rem !important;
  width: 12rem !important;
 } */

 .vault-component {
  height: 10rem;
  width: 12rem;
  padding: 3px;
  margin: 3px;
  display: inline-block;
 }
/*
.masonryholder{
  column-count: 4;
  column-gap: 20px;
  max-width: 1200px;
  margin: 0 auto;
}
.masonryblocks{
  display: inline-block;
  padding: 3px;

  margin: 0 0 15px;
  width: 100%;
box-sizing: border-box;
}

@media screen and (max-width: 768px){
.masonryholder{
  column-count: 1;
}
}
@media screen and (min-width: 769px){
.masonryholder{
  column-count: 2;
}
}
@media screen and (min-width: 1080px){
.masonryholder{
  column-count: 3;
}
}
@media screen and (min-width: 1200px){
.masonryholder{
  column-count: 4;
}
} */
</style>
