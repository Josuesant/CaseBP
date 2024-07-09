using Domain.Entities;
using FluentAssertions;

namespace Unit.Domain.Entities;

public class BaseEntityTests
{
    private const string CreateProperty = "CreateProperty";
    private const string CreateRequestedBy = "CreateRequestedBy";
    private const string UpdateRequestedBy = "UpdateRequestedBy";
    private readonly DateTime _dateTime = DateTime.UtcNow;
    private readonly EntityForTests _entity = new(CreateProperty, CreateRequestedBy);

    [Fact]
    public void Should_create_an_entity()
    {
        _entity.Property.Should().Be(CreateProperty);
        _entity.Id.Should().NotBeEmpty();
        _entity.CriadoEm.Should().BeCloseTo(_dateTime, TimeSpan.FromSeconds(1));
        _entity.UltomaAtualizacao.Should().BeCloseTo(_dateTime, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void Should_update_an_entity()
    {
        const string updateProperty = "UpdateProperty";
        Thread.Sleep(100);

        _entity.UpdateProperty(updateProperty, UpdateRequestedBy);

        _entity.Property.Should().Be(updateProperty);
        _entity.Id.Should().NotBeEmpty();
        _entity.CriadoEm.Should().BeCloseTo(_dateTime, TimeSpan.FromSeconds(1));
        _entity.UltomaAtualizacao.Should().BeAfter(_entity.CriadoEm);
    }

    private class EntityForTests : BaseEntity
    {
        public string Property { get; private set; }

        public EntityForTests(string property, string requestedBy)
        {
            SetCreate(requestedBy);
            Property = property;
        }

        public void UpdateProperty(string property, string requestedBy)
        {
            Property = property;
        }
    }
}