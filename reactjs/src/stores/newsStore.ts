import { action, observable } from 'mobx';
import CreateNewsInput from '../services/news/dto/createNewsInput';
import { EntityDto } from '../services/dto/entityDto';
import { GetAllNewsOutput } from '../services/news/dto/getAllNewsOutput';
import { PagedResultDto } from '../services/dto/pagedResultDto';
import { PagedNewsResultRequestDto } from '../services/news/dto/PagedNewsResultRequestDto';
import NewsModel from '../models/News/NewsModel';
import UpdateNewsInput from '../services/news/dto/updateNewsInput';
import newService from '../services/news/newsService';

class NewsStore {
  @observable news!: PagedResultDto<GetAllNewsOutput>;
  @observable newsModel: NewsModel = new NewsModel();

  @action
  async create(createNewsInput: CreateNewsInput) {
    await newService.create(createNewsInput);
  }

  @action
  async createNews() {
    this.newsModel = {
      id: 0,
      image: '',
      title: '',
      description: '',
      image1: '',  
      image2: '',        
      imageSequence: 0,
      
      
    };
  }

  @action
  async update(updateNewsInput: UpdateNewsInput) {
    let result = await newService.update(updateNewsInput);

    this.news.items = this.news.items.map((x: GetAllNewsOutput) => {
      if (x.id === updateNewsInput.id) x = result;
      return x;
    });
  }

  @action
  async delete(entityDto: EntityDto) {
    await newService.delete(entityDto);
    this.news.items = this.news.items.filter((x: GetAllNewsOutput) => x.id !== entityDto.id);
  }

  @action
  async get(entityDto: EntityDto) {
    let result = await newService.get(entityDto);
    this.newsModel = result;
  }

  @action
  async getAll(pagedFilterAndSortedRequest: PagedNewsResultRequestDto) {
    let result = await newService.getAll(pagedFilterAndSortedRequest);
    this.news = result;
  }
}

export default NewsStore;
