import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepsService {
  async getKeeps() {
    try {
      const res = await api.get('api/keeps')
      console.log(res)
      AppState.keeps = res.data
    } catch (error) {
      console.error(error)
    }
  }

  async getKeep(id) {
    try {
      const res = await api.get('api/keeps/' + id)
      console.log(res)
      AppState.activeKeep = res.data
    } catch (error) {
      console.error(error)
    }
  }

  async getKeepsByAccountId() {
    const res = await api.get('account/keeps')
    console.log(res)
    AppState.keeps = res.data
  }

  async createKeep(keep) {
    await api.post('api/keeps', keep)
    this.getKeeps()
  }

  async deleteKeep(keepId) {
    await api.delete('api/keeps/' + keepId)
    const keepIndex = AppState.keeps.findIndex(k => k.id === keepId)
    AppState.keeps.splice(keepIndex, 1)
  }
}
export const keepsService = new KeepsService()
