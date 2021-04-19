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

  async createKeep(keep) {
    await api.post('api/keeps', keep)
    this.getKeeps()
  }
}
export const keepsService = new KeepsService()
