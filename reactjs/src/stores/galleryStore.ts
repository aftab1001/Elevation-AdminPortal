import { action, observable } from 'mobx';
import CreateGalleryInput from '../services/gallery/dto/createGalleryInput';
import { EntityDto } from '../services/dto/entityDto';
import { GetAllGalleryOutput } from '../services/gallery/dto/getAllGalleryOutput';
import { PagedResultDto } from '../services/dto/pagedResultDto';
import { PagedGalleryResultRequestDto } from '../services/gallery/dto/PagedGalleryResultRequestDto';
import GalleryModel from '../models/Gallery/GalleryModel';
import UpdateGalleryInput from '../services/gallery/dto/updateGalleryInput';
import galleryService from '../services/gallery/galleryService';

class GalleryStore {
  @observable gallerys!: PagedResultDto<GetAllGalleryOutput>;
  @observable galleryModel: GalleryModel = new GalleryModel();

  @action
  async create(createGalleryInput: CreateGalleryInput) {
    await galleryService.create(createGalleryInput);
  }

  @action
  async createGallery() {
    this.galleryModel = {
      id: 0,
      image: '',
      imageTitle: '',
      type: '',
      
    };
  }

  @action
  async update(updateGalleryInput: UpdateGalleryInput) {
    let result = await galleryService.update(updateGalleryInput);

    this.gallerys.items = this.gallerys.items.map((x: GetAllGalleryOutput) => {
      if (x.id === updateGalleryInput.id) x = result;
      return x;
    });
  }

  @action
  async delete(entityDto: EntityDto) {
    await galleryService.delete(entityDto);
    this.gallerys.items = this.gallerys.items.filter((x: GetAllGalleryOutput) => x.id !== entityDto.id);
  }

  @action
  async get(entityDto: EntityDto) {
    let result = await galleryService.get(entityDto);
    this.galleryModel = result;
  }

  @action
  async getAll(pagedFilterAndSortedRequest: PagedGalleryResultRequestDto) {
    let result = await galleryService.getAll(pagedFilterAndSortedRequest);
    this.gallerys = result;
  }
}

export default GalleryStore;
