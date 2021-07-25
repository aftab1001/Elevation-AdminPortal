import { action, observable } from 'mobx';
import CreateResturantInput from '../services/resturant/dto/createResturantInput';
import { EntityDto } from '../services/dto/entityDto';
import { GetAllResturantOutput } from '../services/resturant/dto/getAllResturantOutput';
import { PagedResultDto } from '../services/dto/pagedResultDto';
import { PagedResturantResultRequestDto } from '../services/resturant/dto/PagedResturantResultRequestDto';
import ResturantModel from '../models/Resturants/ResturantModel';
import UpdateResturantInput from '../services/resturant/dto/updateResturantInput';
import resturantService from '../services/resturant/resturantService';

class ResturantStore {
  @observable resturants!: PagedResultDto<GetAllResturantOutput>;
  @observable resturantModel: ResturantModel = new ResturantModel();

  @action
  async create(createResturantInput: CreateResturantInput) {
    await resturantService.create(createResturantInput);
  }

  @action
  async createResturant() {
    this.resturantModel = {
      id: 0,
      image: '',
      name: '',
      description: '',
      category: 0,      
      price: ''
      
    };
  }

  @action
  async update(updateResturantInput: UpdateResturantInput) {
    let result = await resturantService.update(updateResturantInput);

    this.resturants.items = this.resturants.items.map((x: GetAllResturantOutput) => {
      if (x.id === updateResturantInput.id) x = result;
      return x;
    });
  }

  @action
  async delete(entityDto: EntityDto) {
    await resturantService.delete(entityDto);
    this.resturants.items = this.resturants.items.filter((x: GetAllResturantOutput) => x.id !== entityDto.id);
  }

  @action
  async get(entityDto: EntityDto) {
    let result = await resturantService.get(entityDto);
    this.resturantModel = result;
  }

  @action
  async getAll(pagedFilterAndSortedRequest: PagedResturantResultRequestDto) {
    let result = await resturantService.getAll(pagedFilterAndSortedRequest);
    this.resturants = result;
  }
}

export default ResturantStore;
