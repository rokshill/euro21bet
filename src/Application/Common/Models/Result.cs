using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace TournamentForm.Application.Common.Models
{
    public abstract class Result
    {
        protected IEnumerable<string> Errors { get; }
        public abstract bool IsSuccess { get; }

        private Result(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public static Result Ok() => new Success();
        public static Result Fail(IEnumerable<string> errors) => new Failure(errors);
        public static Result Fail(params string[] errors) => new Failure(errors);
        public static Result<T> Ok<T>(T value) => Result<T>.Ok(value);

        public abstract void OnResult(Action onOk, Action<string> onFail);
        public abstract void OnOkResult(Action onSuccess);
        public abstract void OnFailResult(Action<string> onFailure);
        public abstract TMap Map<TMap>(Func<TMap> onOk, Func<string, TMap> onFail);

        public abstract Task<TMap> MapAsync<TMap>(Func<Task<TMap>> onOk, Func<string, Task<TMap>> onFail);
        public abstract Task<TMap> MapAsync<TMap>(Func<Task<TMap>> onOk, Func<string, TMap> onFail);
        public abstract Task<TMap> MapAsync<TMap>(Func<TMap> onOk, Func<string, Task<TMap>> onFail);
        public abstract Task<TMap> MapAsync<TMap>(Func<TMap> onOk, Func<string, TMap> onFail);

        private sealed class Success : Result
        {
            public override bool IsSuccess { get; } = true;

            internal Success() : base(Enumerable.Empty<string>())
            {
            }

            public override void OnResult(Action onOk, Action<string> onFail)
            {
                onOk();
            }

            public override void OnOkResult(Action onSuccess)
            {
                onSuccess();
            }

            public override void OnFailResult(Action<string> onFailure)
            {
            }

            public override TMap Map<TMap>(Func<TMap> onOk, Func<string, TMap> onFail)
            {
                return onOk();
            }

            public override async Task<TMap> MapAsync<TMap>(Func<Task<TMap>> onOk, Func<string, Task<TMap>> onFail)
            {
                return await onOk();
            }

            public override async Task<TMap> MapAsync<TMap>(Func<Task<TMap>> onOk, Func<string, TMap> onFail)
            {
                return await onOk();
            }

            public override async Task<TMap> MapAsync<TMap>(Func<TMap> onOk, Func<string, Task<TMap>> onFail)
            {
                return await Task.FromResult(onOk());
            }

            public override async Task<TMap> MapAsync<TMap>(Func<TMap> onOk, Func<string, TMap> onFail)
            {
                return await Task.FromResult(onOk());
            }

        }

        private sealed class Failure : Result
        {
            public override bool IsSuccess { get; } = false;

            public override void OnResult(Action onOk, Action<string> onFail)
            {
                onFail(GetErrors());
            }

            public override void OnOkResult(Action onSuccess)
            {
            }

            public override void OnFailResult(Action<string> onFailure)
            {
                onFailure(GetErrors());
            }

            public override TMap Map<TMap>(Func<TMap> onOk, Func<string, TMap> onFail)
            {
                return onFail(GetErrors());
            }

            public override async Task<TMap> MapAsync<TMap>(Func<Task<TMap>> onOk, Func<string, Task<TMap>> onFail)
            {
                return await onFail(GetErrors());
            }

            public override async Task<TMap> MapAsync<TMap>(Func<Task<TMap>> onOk, Func<string, TMap> onFail)
            {
                return await Task.FromResult(onFail(GetErrors()));
            }

            public override async Task<TMap> MapAsync<TMap>(Func<TMap> onOk, Func<string, Task<TMap>> onFail)
            {
                return await onFail(GetErrors());
            }

            public override async Task<TMap> MapAsync<TMap>(Func<TMap> onOk, Func<string, TMap> onFail)
            {
                return await Task.FromResult(onFail(GetErrors()));
            }

            private string GetErrors()
            {
                return string.Join(",", Errors);
            }

            internal Failure(IEnumerable<string> errors) : base(errors)
            {
            }
        }
    }

    public class Result<T>
    {
        private readonly Result _result;
        private T Value { get; }

        private Result(T value, Result result)
        {
            this.Value = value;
            _result = result;
        }

        public void OnResult(Action<T> onOk, Action<string> onFail)
        {
            _result.OnResult(() => onOk(Value), onFail);
        }

        public void OnOkResult(Action<T> onSuccess)
        {
            _result.OnOkResult(() => onSuccess(Value));
        }

        public void OnFailResult(Action<string> onFailure)
        {
            _result.OnFailResult(onFailure);
        }

        public TMap Map<TMap>(Func<T, TMap> onOk, Func<string, TMap> onFail)
        {
            return _result.Map(() => onOk(Value), onFail);
        }

        public async Task<TMap> MapAsync<TMap>(Func<T, Task<TMap>> onOk, Func<string, Task<TMap>> onFail)
        {
            return await _result.MapAsync(() => onOk(Value), onFail);
        }

        public async Task<TMap> MapAsync<TMap>(Func<T, TMap> onOk, Func<string, TMap> onFail)
        {
            return await _result.MapAsync(() => onOk(Value), onFail);
        }

        public async Task<TMap> MapAsync<TMap>(Func<T, TMap> onOk, Func<string, Task<TMap>> onFail)
        {
            return await _result.MapAsync(() => onOk(Value), onFail);
        }

        public async Task<TMap> MapAsync<TMap>(Func<T, Task<TMap>> onOk, Func<string, TMap> onFail)
        {
            return await _result.MapAsync(() => onOk(Value), onFail);
        }

        public static Result<T> Ok(T value)
        {
            return new Result<T>(value, Result.Ok());
        }

        public static Result<T> Fail(params string[] errors)
        {
            return new Result<T>(default, Result.Fail(errors));
        }

        public static Result<T> Fail(ValidationResult validationResult, bool ignorePropertyName = false)
        {
            return new Result<T>(default, Result.Fail(validationResult.Errors.ToList().Select(e =>
                string.IsNullOrEmpty(e.PropertyName) || ignorePropertyName ? e.ErrorMessage : $"{e.PropertyName}: {e.ErrorMessage}").ToList()));
        }
    }
    
}
