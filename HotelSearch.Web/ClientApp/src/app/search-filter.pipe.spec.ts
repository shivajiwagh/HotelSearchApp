import { Hotel } from './hotel-model';
import { SearchFilterPipe } from './search-filter.pipe';

describe('SearchFilterPipe', () => {
  let searchFilterPipe: SearchFilterPipe;

  // synchronous beforeEach
  beforeEach(() => {
    searchFilterPipe = new SearchFilterPipe();
  });

  it('create an instance', () => {
    const pipe = new SearchFilterPipe();
    expect(pipe).toBeTruthy();
  });

  it('should be instanciated', () => {
    expect(searchFilterPipe).toBeDefined();
  });

  it('should return empty array if no hotels given', () => {
    let hotels: Hotel[] = [];

    const filteredList = searchFilterPipe.transform(hotels, "test");

    expect(filteredList.length).toBe(0);
    expect(filteredList).toEqual([]);
  });

  it('should return one array if two hotels given', () => {
    let hotels: Hotel[] = [];
    hotels.push({ id: 1, name: "TestHotel", description: "Test desc", location: "Test Loc", rating: 4 });
    hotels.push({ id: 1, name: "Motel test", description: "Highway hotel", location: "highway", rating: 3 });

    const filteredList = searchFilterPipe.transform(hotels, "test");

    expect(filteredList).toEqual(hotels);
  });


});
