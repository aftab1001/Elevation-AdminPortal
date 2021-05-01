import CreateGalleryInput from './dto/createGalleryInput';
import CreateGalleryOutput from './dto/createGalleryOutput';
import { EntityDto } from '../dto/entityDto';
import { GetAllGalleryOutput } from './dto/getAllGalleryOutput';
import GetGalleryOutput from './dto/getGalleryOutput';
import { PagedResultDto } from '../dto/pagedResultDto';
import {PagedGalleryResultRequestDto} from './dto/PagedGalleryResultRequestDto';
import UpdateGalleryInput from './dto/updateGalleryInput';
import UpdateGalleryOutput from './dto/updateGalleryOutput';
import http from '../httpService';

class GalleryService {
  public async create(createGalleryInput: CreateGalleryInput): Promise<CreateGalleryOutput> {
    let result = await http.post('api/services/app/Gallery/Create', createGalleryInput);
    return result.data.result;
  }

  public async delete(entityDto: EntityDto) {
    let result = await http.delete('api/services/app/Gallery/Delete', { params: entityDto });
    return result.data;
  }

  public async get(entityDto: EntityDto): Promise<GetGalleryOutput> {
    let result = await http.get('api/services/app/Gallery/Get', { params: entityDto });
    return result.data.result;
  }

  public async getAll(pagedFilterAndSortedRequest: PagedGalleryResultRequestDto): Promise<PagedResultDto<GetAllGalleryOutput>> {
    let result = await http.get('api/services/app/Gallery/GetAll', { params: pagedFilterAndSortedRequest });
    return result.data.result;
  }

  public async update(updateGalleryInput: UpdateGalleryInput): Promise<UpdateGalleryOutput> {
    let result = await http.put('api/services/app/Gallery/Update', updateGalleryInput);
    return result.data.result;
  }
}

export default new GalleryService();
